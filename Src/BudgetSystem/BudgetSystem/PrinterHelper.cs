using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.LookAndFeel;
using System.Drawing.Printing;
using System.Drawing;

namespace BudgetSystem
{
    public class PrinterHelper
    {
        public static void PrintControl(bool isPrintLandscape, IPrintable printControl, Size customPaperSize, bool isShowPreview = true, PaperKind paperKind = PaperKind.A4, Margins margins = null)
        {
            //if (printControl is ISupportLookAndFeel)
            //{
            //    ISupportLookAndFeel lf = printControl as ISupportLookAndFeel;

            //    lf.LookAndFeel.UseDefaultLookAndFeel = false;
            //    lf.LookAndFeel.SkinName = "Whiteprint";
            //}
            PrintingSystem printingSystem = new PrintingSystem();
            //printingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            PrintableComponentLink printableComponentLink = new PrintableComponentLink();
            if (margins == null)
            {
                margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            }
            // Add the link to the printing system's collection of links.
            printingSystem.Links.AddRange(new object[] { printableComponentLink });
            // Assign a control to be printed by this link.
            printableComponentLink.Component = printControl;

            // Set the paper orientation to Landscape.
            printableComponentLink.Landscape = isPrintLandscape;
            if (paperKind == PaperKind.Custom)
            {
                printableComponentLink.PaperKind = PaperKind.Custom;
                printableComponentLink.CustomPaperSize = customPaperSize;

                printableComponentLink.Margins = margins;
            }
            else
            {
                printableComponentLink.PaperKind = paperKind;
                if (customPaperSize != Size.Empty)
                    printableComponentLink.CustomPaperSize = customPaperSize;
                //printableComponentLink.PaperName = paperKind.;
                printableComponentLink.Margins = margins;
                //var conttrol = (printControl as DevExpress.XtraLayout.LayoutControl);
                //conttrol.Size = new System.Drawing.Size(1200, 1700);
                printableComponentLink.Component = printControl;
                //printableComponentLink.SkipArea = BrickModifier.MarginalFooter;
            }
            if (isShowPreview)
            {
                printableComponentLink.ShowPreview();
            }
            else
            {
                printableComponentLink.Print("");
            }
            //  printableComponentLink.ShowPreview(new UserLookAndFeel(printControl) { UseDefaultLookAndFeel=false, SkinName = "Whileprint" });
        }


    }
}
