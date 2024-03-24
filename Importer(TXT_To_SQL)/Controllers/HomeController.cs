using Entities;
using Entities.ReturnResult;
using EntityService.DBContext;
using Importer_TXT_To_SQL_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace Importer_TXT_To_SQL_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(List<string>? uploadedFileNames = null)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("files", "Please select at least one file.");
                return View("Home/Index");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            List<string> uploadedFileNames = new List<string>();

            // Process each uploaded file
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    // copy file to server
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    uploadedFileNames.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            var responseData = new
            {
                message = "Files uploaded successfully",
                fileNames = uploadedFileNames
            };

            // Return a JSON response with the message and any additional data
            return Json(responseData);
        }

        public async Task<IActionResult> ProcessData([FromBody] ReturnUploadFiles files)
        {
            List<Task> importTasks = new List<Task>();

            foreach (string filename in files.allFiles)
            {
                if (filename.IndexOf("Movies") > 0)
                {
                    importTasks.Add(Task.Run(() => ImportMovie(filename)));
                }
                else if (filename.IndexOf("Ratings") > 0)
                {
                    importTasks.Add(Task.Run(() => ImportRating(filename)));
                }
                else if (filename.IndexOf("Users") > 0)
                {
                    importTasks.Add(Task.Run(() => ImportUser(filename)));
                }
            }

            await Task.WhenAll(importTasks);

            return Json(new { message = "Success" });
        }


        public void ImportMovie(string fileName)
        {
            try
            {


                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    EntityDbContext entityDb = new EntityDbContext();
                    entityDb.Movies.RemoveRange(entityDb.Movies.ToList());
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] rowData = line.Split('|');
                        Movie movie = new Movie();

                        PropertyInfo[] properties = typeof(Movie).GetProperties();
                        int colIndex = 0;

                        foreach (PropertyInfo property in properties)
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                property.SetValue(movie, rowData[colIndex]);
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(movie, int.Parse(rowData[colIndex]));
                            }
                            else if (property.PropertyType == typeof(bool))
                            {
                                property.SetValue(movie, int.Parse(rowData[colIndex]) > 0 ? true : false);
                            }

                            colIndex++;
                        }


                        try
                        {
                            entityDb.Movies.Add(movie);
                        }
                        catch
                        {

                        }

                    }

                    entityDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ImportRating(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    EntityDbContext entityDb = new EntityDbContext();
                    entityDb.Ratings.RemoveRange(entityDb.Ratings.ToList());
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] rowData = line.Split('\t');
                        Rating rating = new Rating();

                        PropertyInfo[] properties = typeof(Rating).GetProperties();
                        int colIndex = 0;

                        foreach (PropertyInfo property in properties)
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                property.SetValue(rating, rowData[colIndex]);
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(rating, int.Parse(rowData[colIndex]));
                            }
                            else if (property.PropertyType == typeof(bool))
                            {
                                property.SetValue(rating, int.Parse(rowData[colIndex]) > 0 ? true : false);
                            }

                            colIndex++;
                        }
                        try
                        {
                            entityDb.Ratings.Add(rating);
                        }
                        catch (Exception e)
                        {

                        }
                    }

                    entityDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ImportUser(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    EntityDbContext entityDb = new EntityDbContext();
                    entityDb.Users.RemoveRange(entityDb.Users.ToList());
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] rowData = line.Split('|');
                        User user = new User();

                        PropertyInfo[] properties = typeof(User).GetProperties();
                        int colIndex = 0;

                        foreach (PropertyInfo property in properties)
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                property.SetValue(user, rowData[colIndex]);
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(user, int.Parse(rowData[colIndex]));
                            }
                            else if (property.PropertyType == typeof(bool))
                            {
                                property.SetValue(user, int.Parse(rowData[colIndex]) > 0 ? true : false);
                            }

                            colIndex++;
                        }

                        try
                        {
                            entityDb.Users.Add(user);
                        }
                        catch
                        {

                        }


                    }

                    entityDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
