﻿
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Application.Animals.Base.DTOs;
using Tamagotchi.Application.Animals.Queries.GetAll.DTOs;
using TamagotchiWeb.Controllers.Base;
using Tamagotchi.Data.DataTableProcessing;
using Tamagotchi.Data.Repositories.Interfaces;
using Tamagotchi.Application.Animals.Commands.Create.DTOs;
using Tamagotchi.Application.Animals.Commands.Update.DTOs;
using Tamagotchi.Application.Animals.Commands.Delete.DTOs;
using Tamagotchi.Application.Animals.Queries.GetUnicId.DTOs;

namespace TamagotchiWeb.Controllers
{
    public class AnimalsController : BaseController<AnimalsController>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AnimalsController(
            IMapper mapper,
            IMediator mediator,
            IAnimalRepository animalRepository,
            ILogger<AnimalsController> logger) : base(logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return GetErrorView(ex);
            }
        }

        [HttpPost]
        public IActionResult GetAll()
        {
            try
            {
                return PartialView("_Table");
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
                var result = await _mediator.Send(new GetAnimalsQuery { DtParameters = data });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new JsonResult(null);
            }
        }

        [HttpPost]
        public IActionResult OpenPopup(GetAnimal model)
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
        public async Task<IActionResult> CreateOrUpdate(GetAnimal model)
        {
            try
            {
                if (model.Name == model.Type)
                {
                    ModelState.AddModelError("isMatchError", "The Name cannot exactly match Type.");
                }
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    if (model.Id is 0)
                    {
                        model.AnimalId = await _mediator.Send(new GetUnicIdQuery());
                        var result = await _mediator.Send(_mapper.Map<CreateAnimalCommand>(model));
                        if(result != null)
                            TempData["success"] = "Animal has created successfully.";
                    }
                    else
                    {
                        var result = await _mediator.Send(_mapper.Map<UpdateAnimalCommand>(model));
                        if (result == null)
                            return NotFound();
                        else
                            TempData["success"] = "Animal has updated successfully.";
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
        public async Task<IActionResult> Delete(GetAnimal model)
        {
            try
            {
                var result = await _mediator.Send(new DeleteAnimalCommand { Id = model.Id });
                if(result == null)
                    return NotFound();

                TempData["success"] = "Animal has deleted successfully.";
                return RedirectToActionPermanent(nameof(Index));
            }
            catch (Exception ex)
            {
                return GetErrorView(ex);
            }
        }
    }
}