using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Entities;
using TicketBooking.Repositories.Interfaces;
using TiketBooking.Web.ViewModels.BusVM;

namespace TiketBooking.Web.Controllers
{
    public class BusesController : Controller
    {
        private readonly IBusRepo busRepo;
        private readonly IMapper mapper;
        private readonly IUtiltyRepo utiltyRepo;
        private string BusImage = "BusImage";

        public BusesController(IBusRepo busRepo, IMapper mapper, IUtiltyRepo utiltyRepo)
        {
            this.busRepo = busRepo;
            this.mapper = mapper;
            this.utiltyRepo = utiltyRepo;
        }
        public async Task<IActionResult> Index()
        {
            var buses =await  busRepo.GetAll();
            var vm = mapper.Map<List<BusViewModel>>(buses);
            return View(vm);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusViewModel vm)
        {
            var model = mapper.Map<Bus>(vm);
            if(vm.BusImage != null)
            {
                model.BusImage = await utiltyRepo.SaveImagePath(BusImage, vm.BusImage);
            }
            await busRepo.Insert(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var busDetail = await busRepo.GetById(id);
              var vm = mapper.Map<EditBusViewModel>(busDetail);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBusViewModel vm)
        {
            var bus = await busRepo.GetById(vm.Id);   
            if(vm.BusImage != null)
            {
                bus.BusImage = await utiltyRepo.EditFilePath(BusImage, vm.BusImage, bus.BusImage);
            }
            bus = mapper.Map(vm, bus);
            await busRepo.Update(bus);

            return RedirectToAction("Index");
        }
    }
}
