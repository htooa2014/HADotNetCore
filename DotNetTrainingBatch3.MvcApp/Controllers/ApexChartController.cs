using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
            {
                Labels = new List<string> { "Team A", "Team B", "Team C", "Team D" },   // "Team E", "Team F", "Team G", "Team H" 
                Series = new List<int> { 44, 55, 13, 43 } //, 22, 10, 60, 14
            };
            return View(model);
        }

        public IActionResult DashedLineChart()
        {
            AppDBContext db = new AppDBContext();
            var list = db.PageStatistics.ToList();
            ApexChartDashedLineResponseModel model = new ApexChartDashedLineResponseModel();
            List<ApexChartDashedLineModel> listSeries = new List<ApexChartDashedLineModel>();
            var listSessionDuration = list.Select(x => x.SessionDuration).ToList();
            var listPageViews = list.Select(x => x.PageViews).ToList();
            var listTotalVisits = list.Select(x => x.TotalVisits).ToList();
            var listCreatedDate = list.Select(x => x.CreatedDate).ToList();

            listSeries.Add(new ApexChartDashedLineModel { name = "Session Duration", data = listSessionDuration });
            listSeries.Add(new ApexChartDashedLineModel { name = "Page Views", data = listPageViews });
            listSeries.Add(new ApexChartDashedLineModel { name = "Total Visits", data = listTotalVisits });

            model.Series = listSeries;
            model.Labels = listCreatedDate;


            return View(model);
        }

        public IActionResult RadarChart(int id)
        {
            
            AppDBContext db = new AppDBContext();
            var list = db.Radar.ToList();
            ApexChartRadarResponseModel model = new ApexChartRadarResponseModel();
            List<ApexChartRadarModel> listSeries = new List<ApexChartRadarModel>();
            var listSeries1 = list.Select(x => x.Series1).ToList();           
            var listMonth = list.Select(x => x.Month).ToList();

          
            

            listSeries.Add(new ApexChartRadarModel { name = "Series 1", data = listSeries1 });

            if(id == 1)
            {
                var listSeries2 = list.Select(x => x.Series2).ToList();
                var listSeries3 = list.Select(x => x.Series3).ToList();

                listSeries.Add(new ApexChartRadarModel { name = "Series 2", data = listSeries2 });
                listSeries.Add(new ApexChartRadarModel { name = "Series 3", data = listSeries3 });
            
            }
               

            model.Series = listSeries;
            model.Labels = listMonth;


            return View(model);
        }
    }
}
