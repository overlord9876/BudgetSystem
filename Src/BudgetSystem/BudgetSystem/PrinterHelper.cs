using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.LookAndFeel;

namespace BudgetSystem
{
    public class PrinterHelper
    {
        public static void PrintControl(bool isPrintLandscape, IPrintable printControl, bool isShowPreview = true)
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



            // Add the link to the printing system's collection of links.
            printingSystem.Links.AddRange(new object[] { printableComponentLink });
            // Assign a control to be printed by this link.
            printableComponentLink.Component = printControl;
            // Set the paper orientation to Landscape.
            printableComponentLink.Landscape = isPrintLandscape;
            printableComponentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
            printableComponentLink.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
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
