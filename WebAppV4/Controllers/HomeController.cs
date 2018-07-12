using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppV4.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebAppV4.Models.File;
using Microsoft.AspNetCore.Http;
using WebAppV4.Models.Text;
using WebAppV4.Models.ReadText;

namespace WebAppV4.Controllers
{
    public class HomeController : Controller
    {
        //private FileContext _context;
        //private TextModel _textmodel;
        FileModel file = new FileModel();
        private List<string> _arraymass;
        private int _length;
        private int _lengthall;
        private IHostingEnvironment _appEnvironment;
        public HomeController(/*FileContext context, */IHostingEnvironment appEnvironment)
        {
            //_context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(/*_context.Files.ToList()*/);
        }
        

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
           ReadFile readfile = new ReadFile();
            string result = "";
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        string pathfile = "D:/Практика/WebAppV4/WebAppV4/wwwroot/wwwroot/Files/" + uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    
                    file.Name = uploadedFile.FileName;
                    file.Path = pathfile;
                    readfile.Open(file.Path);
                    _arraymass = readfile.StringMass;
                    _length = readfile.LengthMass;
                    _lengthall = readfile.LengthAllMass;
                }
            }

            result = $"Количество слов в тексте: {_lengthall} \n";
            result += $"Количество уникальные слова, длина которых больше: {_length} \n";
            result += $"Уникальные слова, длина которых больше: \n";
            foreach (string p in _arraymass)
            {
                result += p;
                result += ";\n";
            }
            return Content(result);
        }

        public IActionResult InPut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReadText(TextModel textmodel)
        {

            string result = "";
            if (ModelState.IsValid)
            {
                string text = textmodel.Text;
                ReadText readtext = new ReadText();
                readtext.Open(text);
                _arraymass = readtext.StringMass;
                _length = readtext.LengthMass;
                _lengthall = readtext.LengthAllMass;
            }

            result = $"Количество слов в тексте: {_lengthall} \n";
            result += $"Количество уникальные слова, длина которых больше: {_length} \n";
            result += $"Уникальные слова, длина которых больше: \n";
            foreach (string p in _arraymass)
            {
                result += p;
                result += ";\n";
            }
            return Content(result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
