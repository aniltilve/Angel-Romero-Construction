using ARC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ARC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (DAC.Database database = new DAC.Database())
            {
                Models.SiteLanguage siteLanguage =
                    database.SiteLanguage.FirstOrDefault(SiteVariable => SiteVariable.code.ToUpper()
                        == Classes.Constant.Con_SiteLanguageOverviewCode);

                return View(siteLanguage);
            }
        }

        public ActionResult Services()
        {
            ViewBag.Message = "You application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contactModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                    //SmtpClient smtpClient = new SmtpClient();
                    //MailAddress from = new MailAddress(contactModel.Email.ToString());
                    //StringBuilder stringBuilder = new StringBuilder();
                    //message.To.Add("youremail@email.com");
                    //message.Subject = "Contact Us";
                    //message.IsBodyHtml = false;
                    //smtpClient.Host = "mail.yourdomain.com";
                    //smtpClient.Port = 25;
                    //stringBuilder.Append("First name: " + contactModel.Name);
                    //stringBuilder.Append(Environment.NewLine);
                    //stringBuilder.Append("Email: " + contactModel.Email);
                    //stringBuilder.Append(Environment.NewLine);
                    //stringBuilder.Append("Comments: " + contactModel.Comment);
                    //message.Body = stringBuilder.ToString();
                    //smtpClient.Send(message);
                    //message.Dispose();
                    //return View("Success");
                    using (DAC.Database database = new DAC.Database())
                    {
                        bool SentMail = true;
                        try
                        {

                            string Subject = WebConfigurationManager.AppSettings["Subject"].ToString();
                            string Body = "Name : " + contactModel.name + System.Environment.NewLine
                                + "Email : " + contactModel.email + System.Environment.NewLine
                                + "Phone Number : " + contactModel.phone + System.Environment.NewLine
                                + "Comment : " + contactModel.comment;

                            Classes.Email.Send(Subject, Body);
                        }
                        catch (Exception Ex)
                        {
                            SentMail = false;
                        }
                        contactModel.creationDate = DateTime.Now;
                        contactModel.emailSentFlag = SentMail;
                        database.Contact.Add(contactModel);
                        database.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception Ex)
                {
                    throw;
                }
            }
            return View(contactModel);
        }

        public ActionResult Portfolio()
        {
            List<ARCImage> images = null;
            List<ImageType> imageTypes = null;

            using (DAC.Database database = new DAC.Database())
            {
                imageTypes = database.ImageType.Where(x => x.code.Contains("portfolio")).ToList();

                foreach (var imageType in imageTypes)
                {
                    if (images == null)
                        images = database.ARCImage.Where(x => imageType.id == x.typeID).ToList();
                    else
                        images = images.Concat( database.ARCImage.Where(x => imageType.id == x.typeID).ToList() ).ToList();
                }
            }

            ViewBag.Images = images;
            ViewBag.ImageTypes = imageTypes;

            return View();
        }

        public ActionResult Review()
        {
            ViewBag.AddMode = false;

            Review review = new Review();

            using (DAC.Database database = new DAC.Database())
            {
                review.reviews = database.Review.OrderByDescending(x => x.creationDate).Take(10).ToList();
            }
            return View(review);
        }

        [HttpPost]
        public ActionResult Review(Review review)
        {
            ViewBag.AddMode = true;

            review.creationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                using (DAC.Database database = new DAC.Database())
                {
                    database.Review.Add(review);
                    database.SaveChanges();
                }
                return RedirectToAction("Review");
            }

            using (DAC.Database database = new DAC.Database())
            {
                review.reviews = database.Review.OrderByDescending(x => x.creationDate).Take(10).ToList();
            }
            
            return View(review);
        }
    }
}