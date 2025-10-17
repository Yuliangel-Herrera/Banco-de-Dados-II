using EFAereoNuvem.Models;
using EFAereoNuvem.Repository;
using EFAereoNuvem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EFAereoNuvem.Controllers
{
    public class FlightController(IFlightRepository flightRepository, ILogger<FlightController> logger) : Controller
    {
        private readonly IFlightRepository _flightRepository = flightRepository;
        private readonly ILogger<FlightController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            try
            {
                var flights = await _flightRepository.GetAll();
                return View(flights);
            }
            catch (Exception ex)
            {
                // Exemplo: registre no logger
                _logger.LogError(ex, "Erro ao buscar voos.");
                TempData["ErrorMessage"] = "Não foi possível carregar os voos no momento.";
                return View(new List<Flight>()); 
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return View(flight);
            }

            try
            {
                await _flightRepository.Create(flight);
                TempData["SuccessMessage"] = "Voo cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar voo.");
                TempData["ErrorMessage"] = "Ocorreu um erro ao salvar o voo.";
                return View(flight);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var flight = await _flightRepository.GetById(Id);
            if (flight == null)
            {
                return NotFound();
            }
            await _flightRepository.Delete(flight);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightRepository.GetById(id.Value);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _flightRepository.Update(flight);
                    TempData["SuccessMessage"] = "Estudante atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao atualizar o estudante.");
                }
            }

            return View(flight);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
