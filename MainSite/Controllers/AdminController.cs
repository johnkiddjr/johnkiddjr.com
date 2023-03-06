using Infrastructure.Contexts;
using Infrastructure.Models;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly MainSiteContext _context;

        public AdminController(ILogger<AdminController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index(string message = "")
        {
            var viewModel = GenerateViewModel(message);

            return View(viewModel);
        }

        [HttpGet("AddSection")]
        public IActionResult AddAdminSection()
        {
            var viewModel = new AdminSectionViewModel();

            return View(viewModel);
        }

        [HttpGet("AddSectionItem")]
        public IActionResult AddAdminSectionItem(string selectedSectionId = "")
        {
            var viewModel = new AdminSectionItemViewModel();
            var listOfSections = (from sections in _context.AdminSections
                                  select new AdminSectionViewModel
                                  {
                                      HeaderText = sections.SectionTitle,
                                      SectionId = sections.AdminSectionId.ToString(),
                                      SectionItems = (from item in _context.AdminSectionsItems
                                                      where item.AdminSectionId == sections.AdminSectionId
                                                      select new AdminSectionItemViewModel
                                                      {
                                                          AdminSectionId = item.AdminSectionId.ToString(),
                                                          LinkText= item.LinkText,
                                                          LinkUrl= item.LinkUrl
                                                      }).ToList()
                                  }).ToList();

            ViewBag.AdminSections = listOfSections;

            if (!string.IsNullOrWhiteSpace(selectedSectionId))
            {
                viewModel.AdminSectionId = selectedSectionId;
            }

            return View(viewModel);
        }

        //[HttpGet("RemoveAdminSection")]
        //public IActionResult RemoveAdminSection()
        //{
        //    return Ok();
        //}

        //[HttpGet("RemoveAdminSectionItem")]
        //public IActionResult RemoveAdminSectionItem(string selectedSectionId)
        //{
        //    return Ok();
        //    //var viewModel = new AdminSectionItemViewModel();
        //    //var listOfSections = (from sections in _context.AdminSections
        //    //                      select new AdminSectionViewModel
        //    //                      {
        //    //                          HeaderText = sections.SectionTitle,
        //    //                          SectionId = sections.AdminSectionId.ToString(),
        //    //                          SectionItems = (from item in _context.AdminSectionsItems
        //    //                                          where item.AdminSectionId == sections.AdminSectionId
        //    //                                          select new AdminSectionItemViewModel
        //    //                                          {
        //    //                                              AdminSectionId = item.AdminSectionId.ToString(),
        //    //                                              LinkText = item.LinkText,
        //    //                                              LinkUrl = item.LinkUrl
        //    //                                          }).ToList()
        //    //                      }).ToList();

        //    //ViewBag.AdminSections = listOfSections;

        //    //if (!string.IsNullOrWhiteSpace(selectedSectionId))
        //    //{
        //    //    viewModel.AdminSectionId = selectedSectionId;
        //    //}

        //    //return View(viewModel);
        //}

        [HttpPost("AddSection")]
        public IActionResult AddAdminSection(AdminSectionViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.HeaderText))
            {
                ModelState.AddModelError("", "Section Header must not be empty!");
                return View(viewModel);
            }

            AdminSection newSection = new AdminSection
            {
                SectionTitle = viewModel.HeaderText
            };

            _context.AdminSections.Add(newSection);

            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", new { message = $"Section \"{viewModel.HeaderText}\" Added!" });
            }

            ModelState.AddModelError("", "Unable to save changes to database!");
            return View(viewModel);
        }

        [HttpPost("AddSectionItem")]
        public IActionResult AddAdminSectionItem(AdminSectionItemViewModel viewModel)
        {
            //validation...
            if (string.IsNullOrWhiteSpace(viewModel.AdminSectionId))
            {
                ModelState.AddModelError("", "Admin Section ID not set!");
                return View(viewModel);
            }

            if (string.IsNullOrWhiteSpace(viewModel.LinkText))
            {
                ModelState.AddModelError("", "Link Text must have a value!");
                return View(viewModel);
            }

            if (string.IsNullOrWhiteSpace(viewModel.LinkUrl))
            {
                ModelState.AddModelError("", "Link Url must have a value!");
                return View(viewModel);
            }

            AdminSectionItem newItem = new AdminSectionItem
            {
                AdminSectionId = Guid.Parse(viewModel.AdminSectionId),
                LinkText = viewModel.LinkText,
                LinkUrl = viewModel.LinkUrl
            };

            _context.AdminSectionsItems.Add(newItem);

            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", new { message = $"Item added successfully!" });
            }

            ModelState.AddModelError("", "");
            return View(viewModel.AdminSectionId);
        }

        private AdminViewModel GenerateViewModel(string message)
        {
            var viewModel = new AdminViewModel();
            viewModel.Message = message;
            viewModel.Sections = new List<AdminSectionViewModel>();

            var adminSections = (from admin in _context.AdminSections
                                 select admin).ToList();

            if (adminSections != null && adminSections.Any())
            {
                foreach (var section in adminSections)
                {
                    var filledInSection = new AdminSectionViewModel
                    {
                        HeaderText = section.SectionTitle,
                        SectionItems = new List<AdminSectionItemViewModel>()
                    };

                    var adminSectionItems = (from sec in _context.AdminSectionsItems
                                             where sec.AdminSectionId == section.AdminSectionId
                                             select sec).ToList();

                    if (adminSectionItems != null && adminSectionItems.Any())
                    {
                        foreach (var item in adminSectionItems)
                        {
                            filledInSection.SectionItems.Add(new AdminSectionItemViewModel
                            {
                                LinkText = item.LinkText,
                                LinkUrl = item.LinkUrl,
                                AdminSectionId = item.AdminSectionId.ToString()
                            });
                        }
                    }

                    viewModel.Sections.Add(filledInSection);
                }

                return viewModel;
            }

            return null;
        }
    }
}
