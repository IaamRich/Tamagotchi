﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Application.AnimalTypes.Base.DTOs;
using Tamagotchi.Application.AnimalTypes.Quieries.GetAll.DTOs;
using Tamagotchi.Web.Controllers.Base;
using Tamagotchi.Data.DataTableProcessing;
using Tamagotchi.Application.AnimalTypes.Commands.Create.DTOs;
using Tamagotchi.Application.AnimalTypes.Commands.Update.DTOs;
using Tamagotchi.Application.AnimalTypes.Commands.Delete.DTOs;
using Tamagotchi.Web.Services.Interfaces;
using Tamagotchi.Application.Exceptions;
using Tamagotchi.Application.Localization.Interface;

namespace Tamagotchi.Web.Controllers
{
    public class AnimalTypesController : BaseController<AnimalTypesController>
    {
        private readonly IAnimalTypeService _animalTypeService;
        private readonly ILocalizationService localizer;

        public AnimalTypesController(
            IMediator mediator,
            IMapper mapper,
            ITokenService tokenService,
            IAnimalTypeService animalTypeService,
            ILocalizationService localizationService,
            ILogger<AnimalTypesController> logger) : base(mapper, mediator, tokenService, logger)
        {
            _animalTypeService = animalTypeService;
            localizer = localizationService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tempText = localizer["start"];
                return View();
            }
            catch (Exception ex)
            {
                return GetErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetPaginatedTable(DtParameters data)
        {
            try
            {
                var result = await Mediator.Send(new GetAnimalTypesQuery { DtParameters = data });
                
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new JsonResult(null);
            }
        }

        [HttpPost]
        public IActionResult OpenPopup(GetAnimalType model)
        {
            try
            {
                return PartialView("Popups/CreateUpdatePopup", model);
            }
            catch (Exception ex) 
            {
                return GetErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(GetAnimalType model)
        {
            try
            {
                if(model.Name == model.Coats)
                {
                    ModelState.AddModelError("isMatchError", "The Name cannot exactly match coats.");
                }
                if(ModelState.IsValid)
                {
                    ModelState.Clear();
                    if (model.Id is 0)
                    {
                        var result = await Mediator.Send(Mapper.Map<CreateAnimalTypeCommand>(model));
                        if (result != null)
                            TempData["success"] = "Animal type has created successfully.";
                    }
                    else
                    {
                        var result = await Mediator.Send(Mapper.Map<UpdateAnimalTypeCommand>(model));
                        if (result == null)
                            return NotFound();
                        else
                            TempData["success"] = "Animal type has updated successfully.";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return GetErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GetAnimalType model)
        {
            try
            {
                var result = await Mediator.Send(new DeleteAnimalTypeCommand { Id = model.Id });
                if (result == null)
                    return NotFound();

                TempData["success"] = "Animal type deleted successfully.";
                return RedirectToActionPermanent(nameof(Index));
            }
            catch (Exception ex)
            {
                return GetErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Synch()
        {
            try
            {
                var dbAnimalTypes = await Mediator.Send(new GetAnimalTypesQuery { DtParameters = GetStandardParameters() });
                var petFinderAnimalTypes = await _animalTypeService.GetAnimalTypes();

                foreach (var item in petFinderAnimalTypes.AnimalTypes)
                {
                    var obj = dbAnimalTypes.Data.FirstOrDefault(x => x.Name == item.Name);
                    if (obj == null)
                    {
                        var result = await Mediator.Send(Mapper.Map<CreateAnimalTypeCommand>(item));
                        if(result == null)
                            Console.WriteLine("Something went wrong with creation " + item.Name + " Animal Type");
                        else
                            Console.WriteLine("Animal Type " + result.Name + " has added");
                    }
                }
            }
            catch (WebServiceException ex)
            {
                if(ex.Errors.Contains("Unauthorized"))
                {
                    var isUpdatedPetFinderToken = await TokenService.GetPetFinderToken();
                    if (isUpdatedPetFinderToken)
                        await Synch();
                    else
                        ModelState.AddModelError("authorizationError", "Something went wrong with getting PetFinder token!");
                }
                else
                    ModelState.AddModelError("webServiceError", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("synchError", ex.Message);
            }

            return RedirectToAction("index");
        }
    }
}