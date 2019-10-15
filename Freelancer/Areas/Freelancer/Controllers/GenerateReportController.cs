using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using Microsoft.Reporting.WinForms;

namespace Freelancer.Areas.Freelancer.Controllers
{
    public class GenerateReportController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();
        
        // GET: Freelancer/GenerateReport
        public ActionResult InvoiceIndex()
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());


            return View(db.Invoices.Where(a => a.ServiceRequest.Job.freelancerID == id).ToList());
        }

        public ActionResult SummaryReport()
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());
            List<ServiceRequest> services = db.ServiceRequests.Where(a => a.Job.freelancerID == id && a.verified == true).ToList();
            FreelancerClient freelancerObj = db.FreelancerClients.Find(id);
            CompetitiveSummary competitiveSummary = new CompetitiveSummary(freelancerObj);
            ProfitSummary profitSummary = new ProfitSummary(id, services);

            if (freelancerObj != null)
            {
                profitSummary.setProfitSummary();
                competitiveSummary.calculateCompetitiveSummary();
            }

            SummaryReportData summary = new SummaryReportData()
            {
                marketRevenue = Math.Round(competitiveSummary.getRevenue(), 2),
                marketShare = Math.Round(competitiveSummary.getMarketShare(), 2),
                numFreelancers = competitiveSummary.getFreelancers(),
                servicesRendered = services.Count(),
                totalCustomers = services.Count(),
                weeklyEarnings = profitSummary.weeklyEarnings,
                totalEarnings = profitSummary.totalEarnings

            };

            return View(summary);
        }
        [HttpPost]
        public ActionResult InvoiceIndex(FormCollection form)
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());
            DateTime startTime = Convert.ToDateTime(form["startTime"]);
            DateTime endTime = Convert.ToDateTime(form["endTime"]);

            List<Invoice> invoiceList = db.Invoices.Where(a => a.invoiceDate >= startTime && a.invoiceDate <= endTime).ToList();
            
            return View(invoiceList);
        }

        public ActionResult Reports(string ReportType)
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/FreelancerReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "InvoiceDataSet";
            reportDataSource.Value = db.Invoices.Where(a => a.ServiceRequest.Job.freelancerID == id).ToList();
            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            switch(reportType)
            {
                case "Excel":
                    fileNameExtension = "xlsx";
                    break;

                case "PDF":
                    fileNameExtension = "pdf";
                    break;

                case "Word":
                    fileNameExtension = "docx";
                    break;

                default:
                    fileNameExtension = "jpg";
                    break;
            }


            string[] streams;
            Warning[] warnings;
            byte[] reneredByte;

            reneredByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename= invoiceReport." + fileNameExtension);

            return File(reneredByte, fileNameExtension);
        }
    }
}