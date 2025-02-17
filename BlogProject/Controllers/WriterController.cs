using BlogProject.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
	[AllowAnonymous]
	public class WriterController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IWriterService _writerService;
		private readonly IFileService _fileService;
		public WriterController(IBlogService blogService, IWriterService writerService, IFileService fileService)
		{
			_blogService = blogService;
			_writerService = writerService;
			_fileService = fileService;
		}


		public IActionResult Index()
		{
			//ViewBag.AllBlogCount = _blogService.GetAll().Count();
			//ViewBag.AllBlogCountByWriter = _blogService.GetAll().Where(x => x.WriterID == 3).Count();
			return View();
		}


		[HttpGet]
		public IActionResult WriterEditBlogs()
		{
			return View(_blogService.GetAllBlogByWriter(3));
		}


		

		[HttpGet]
		public IActionResult GetWriterInformation()
		{
			InsertWriterModel ınsertWriterModel = new InsertWriterModel();
			var writerEntity = _writerService.GetById(3);
			ınsertWriterModel.WriterID = writerEntity.WriterID;
			ınsertWriterModel.WriterName = writerEntity.WriterName;
			ınsertWriterModel.WriterAbout = writerEntity.WriterAbout;
			ınsertWriterModel.WriterMail = writerEntity.WriterMail;
			ınsertWriterModel.WriterPassword = writerEntity.WriterPassword;
			ınsertWriterModel.WriterStatus = writerEntity.WriterStatus;
			return View(ınsertWriterModel);
		}

		[HttpPost]
		public IActionResult GetWriterInformation(InsertWriterModel entity)
		{
			var imageName = _fileService.FileAdd(entity.WriterImage.FileName, entity.WriterImage);

			Writer toBeAddedWriter = new Writer();

			toBeAddedWriter.WriterID = entity.WriterID;
			toBeAddedWriter.WriterName = entity.WriterName;
			toBeAddedWriter.WriterAbout = entity.WriterAbout;
			toBeAddedWriter.WriterMail = entity.WriterMail;
			toBeAddedWriter.WriterPassword = entity.WriterPassword;
			toBeAddedWriter.WriterImage = imageName;
			toBeAddedWriter.WriterStatus = true;

			WriterValidator writerValidator = new WriterValidator();
			ValidationResult validationResult = writerValidator.Validate(toBeAddedWriter);
			if (!validationResult.IsValid)
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}

			_writerService.Update(toBeAddedWriter);
			return RedirectToAction("Index", "Writer");
		}
	}
}
