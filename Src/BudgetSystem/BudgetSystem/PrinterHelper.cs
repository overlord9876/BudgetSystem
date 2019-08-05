using System;
using System.Collections.Generic;
using System.Text;
using BudgetSystem.Entity;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.LookAndFeel;
using System.Drawing.Printing;

namespace BudgetSystem
{
    public class PrinterHelper
    {
        public static void PrintControl(bool isPrintLandscape, IPrintable printControl, bool isShowPreview = true, PaperKind paperKind = PaperKind.A4)
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
            printableComponentLink.PaperKind = paperKind;
            if (paperKind == PaperKind.Custom)
            {
                printableComponentLink.PaperKind = PaperKind.Custom;
                printableComponentLink.CustomPaperSize = new System.Drawing.Size((int)(210 * 100 / 25.4), (int)(139.8 * 100 / 25.4 ));

                printableComponentLink.Margins = new System.Drawing.Printing.Margins(50, 10, 10, 10);
            }
            else
            {
                printableComponentLink.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
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
