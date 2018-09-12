using Expense.Models;
using Expense.ViewModels;
using Expense.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;

namespace Expense.Controllers
{
  
    public class ItemsController : Controller
    {
        // GET: Item
        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            var item = _context.Items.Include(c => c.CategoryType).ToList();
            return View(item);
        }
        public ViewResult New()
        {
            var category = _context.CategoryTypes.ToList();
            var viewModel = new ItemFormViewModel
            {
                CategoryTypes = category
            };
            return View("ItemForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(c => c.Id == id);
            if (item == null)
                return HttpNotFound();
            var viewModel = new ItemFormViewModel
            {
                Item = item,
                CategoryTypes = _context.CategoryTypes.ToList()
            };
            return View("ItemForm", viewModel);
        }

        public ActionResult Save(Item item)
        {
            if (item.Id == 0)
            {

                _context.Items.Add(item);
            }
            else
            {
                var itemInDb = _context.Items.Single(m => m.Id == item.Id);
                itemInDb.Name = item.Name;
                itemInDb.CategoryType = item.CategoryType;
                itemInDb.CategoryTypeId = item.CategoryTypeId;
                itemInDb.Amount = item.Amount;
                itemInDb.ExpenseDate = item.ExpenseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Items");
        }

        public ActionResult Delete(int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Items");

        }
        public ActionResult Filter(string searchString)
        {
            var item = from m in _context.Items
                       select m;
            item = item.Include(c => c.CategoryType);

            if (!String.IsNullOrEmpty(searchString))
            {
                item = item.Where(s => s.Name.Contains(searchString));
            }
            else
                return RedirectToAction("Index", "Items");

            return View("Index", item);
        }
        public ActionResult Report()
        {
            var item = _context.Items.Include(c => c.CategoryType).ToList();
            return View("Report", item);
        }

        public ActionResult Chart()
        {
            Highcharts columnChart = new Highcharts("columnchart");
            double foodExpense1 = 0;
            double shoppingExpense1 = 0;
            double travelExpense1 = 0;
            double healthExpense1 = 0;
            double foodExpense2 = 0;
            double shoppingExpense2 = 0;
            double travelExpense2 = 0;
            double healthExpense2 = 0;
            DateTime lastsixmonth = DateTime.Now.AddMonths(-6);
            DateTime lastonemonth = DateTime.Now.AddMonths(-1);


            var item1 = from m in _context.Items
                        where m.CategoryTypeId == 1
                        where m.ExpenseDate > lastsixmonth
                        select m;


            foreach (var a in item1)
            {
                foodExpense1 += a.Amount;
            }

            var item2 = from m in _context.Items
                        where m.CategoryTypeId == 2
                        where m.ExpenseDate > lastsixmonth
                        select m;


            foreach (var a in item2)
            {
                shoppingExpense1 += a.Amount;
            }

            var item3 = from m in _context.Items
                        where m.CategoryTypeId == 3
                        where m.ExpenseDate > lastsixmonth
                        select m;


            foreach (var a in item3)
            {
                travelExpense1 += a.Amount;
            }

            var item4 = from m in _context.Items
                        where m.CategoryTypeId == 4
                        where m.ExpenseDate > lastsixmonth
                        select m;


            foreach (var a in item4)
            {
                healthExpense1 += a.Amount;
            }

            var newitem1 = from m in _context.Items
                           where m.CategoryTypeId == 1
                           where m.ExpenseDate > lastonemonth
                           select m;


            foreach (var a in newitem1)
            {
                foodExpense2 += a.Amount;
            }

            var newitem2 = from m in _context.Items
                           where m.CategoryTypeId == 2
                           where m.ExpenseDate > lastonemonth
                           select m;


            foreach (var a in newitem2)
            {
                shoppingExpense2 += a.Amount;
            }

            var newitem3 = from m in _context.Items
                           where m.CategoryTypeId == 3
                           where m.ExpenseDate > lastonemonth
                           select m;


            foreach (var a in newitem3)
            {
                travelExpense2 += a.Amount;
            }

            var newitem4 = from m in _context.Items
                           where m.CategoryTypeId == 4
                           where m.ExpenseDate > lastonemonth
                           select m;


            foreach (var a in newitem4)
            {
                healthExpense2 += a.Amount;
            }

            double total1 = foodExpense1 + shoppingExpense1 + travelExpense1 + healthExpense1;
            double total2 = foodExpense2 + shoppingExpense2 + travelExpense2 + healthExpense2;

            columnChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 3

            });

            columnChart.SetTitle(new Title()
            {
                Text = "Expense Report"
            });

            columnChart.SetSubtitle(new Subtitle()
            {
                Text = "6 months expense is " + total1 + ", 4 weeks expense is " + total2
            });


            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Category", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = new[] { "Food", "shopping", "Travel", "Health" }
            });

            columnChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "expense",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = System.Drawing.Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

            columnChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "6 months expense",
                    Data = new Data(new object[] {  foodExpense1, shoppingExpense1, travelExpense1, healthExpense1  })
                },
                 new Series{

                    Name = "4 weeks expense",
                    Data = new Data(new object[] {  foodExpense2, shoppingExpense2, travelExpense2, healthExpense2  })
                }

            }
            );

            return View("Chart", columnChart);
        }
    }
}