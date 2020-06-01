using System.Web;
using System.Web.Optimization;

namespace TicketBooking.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Content/ticketbookingapp/plugins/fast-click/fastclick.min.js",
                        "~/Content/ticketbookingapp/js/scripts.js",
                        "~/Content/ticketbookingapp/plugins/switchery/switchery.min.js",
                        "~/Content/ticketbookingapp/plugins/parsley/parsley.min.js",
                        "~/Content/ticketbookingapp/plugins/jquery-steps/jquery-steps.min.js",
                        "~/Content/ticketbookingapp/plugins/bootstrap-select/bootstrap-select.min.js",
                        "~/Content/ticketbookingapp/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
                        "~/Content/ticketbookingapp/plugins/masked-input/bootstrap-inputmask.min.js",
                        "~/Content/ticketbookingapp/plugins/bootstrap-validator/bootstrapValidator.min.js",
                        "~/Content/ticketbookingapp/plugins/bootstrap-validator/bootstrapValidator.min.js",
                        "~/Content/ticketbookingapp/plugins/flot-charts/jquery.flot.min.js",
                        "~/Content/ticketbookingapp/plugins/flot-charts/jquery.flot.resize.min.js",
                        "~/Content/ticketbookingapp/plugins/flot-charts/jquery.flot.categories.js",
                        "~/Content/ticketbookingapp/plugins/jvectormap/jquery-jvectormap.min.js",
                        "~/Content/ticketbookingapp/plugins/jvectormap/jquery-jvectormap-us-aea-en.js",
                        "~/Content/ticketbookingapp/plugins/easy-pie-chart/jquery.easypiechart.min.js",
                        "~/Content/ticketbookingapp/plugins/screenfull/screenfull.js",
                        "~/Content/ticketbookingapp/plugins/datatables/media/js/jquery.dataTables.js",
                        "~/Content/ticketbookingapp/plugins/datatables/media/js/dataTables.bootstrap.js",
                        "~/Content/ticketbookingapp/plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js",
                        "~/Content/ticketbookingapp/js/demo/tables-datatables.js",
                        "~/Content/ticketbookingapp/js/demo/index.js",
                        "~/Content/ticketbookingapp/js/demo/wizard.js",
                        "~/Content/ticketbookingapp/js/demo/jasmine.js",
                        "~/Content/ticketbookingapp/js/demo/form-wizard.js",
                        "~/Content/ticketbookingapp/plugins/pace/pace.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/ticketbookingapp/css/bootstrap.min.css",
                      "~/Content/ticketbookingapp/css/style.css",
                      "~/Content/ticketbookingapp/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/ticketbookingapp/plugins/switchery/switchery.min.css",
                      "~/Content/ticketbookingapp/plugins/bootstrap-select/bootstrap-select.min.css",
                      "~/Content/ticketbookingapp/plugins/bootstrap-validator/bootstrapValidator.min.css",
                      "~/Content/ticketbookingapp/plugins/jvectormap/jquery-jvectormap.css",
                      "~/Content/ticketbookingapp/plugins/datatables/media/css/dataTables.bootstrap.css",
                      "~/Content/ticketbookingapp/plugins/datatables/extensions/Responsive/css/dataTables.responsive.css",
                      "~/Content/ticketbookingapp/css/demo/jquery-steps.min.css",
                      "~/Content/ticketbookingapp/css/demo/jasmine.css",
                      "~/Content/ticketbookingapp/plugins/pace/pace.min.css"));
        }
    }
}
