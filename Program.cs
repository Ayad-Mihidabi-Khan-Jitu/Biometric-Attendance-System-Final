using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biometric_Attendence_System
    {
    static class Program
        {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
            {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Splash());
            Application.Run(new SplashWithSketch());
            //Application.Run(new Login());
            //Application.Run(new AdminLogin());
            //Application.Run(new AdminPanel());
            //Application.Run(new TeachersPanel());
            //Application.Run(new StudentsPanel());
            //Application.Run(new TeachersList());
            //Application.Run(new StudentsList());
            //Application.Run(new AttendenceDetails());
            //Application.Run(new LoadingForm());



            /*
            Project er Bug
            ----------------
            1. Image: (AdminPane.cs)
                 Image Database theke image box e show kore na
            2. Unexpected Deletion: (AdminPane.cs)
                Combobox e kono kichu select na korlew available smallest index er row ta delete hoye jay
                NOTE- form ta load howar sathe sathe combobox er available smallest index ta selected hoy
                              amar mone hoy aijonnoi both Teacher and Course ta delete hoye jacche
            3. DoNot Delete: (AdminPane.cs)
                No. 2 problem theke uttoroner jonno deletion perform e sorto dilam je- if(Role == "admin") Do not delete
                ataw kaj kore na delete kore fele.
            4.Unrefreshed Datatable: (AdminPane.cs)
                Insert/Update/Delete er por  DataTable guli automatic refresh hocche na 
            5. Column Could not found: (TeacherPanel.cs)
                Course Table e [Course_Semester] ache tobuo jokhon CourseTbl theke CourseTbl.Select() kori tokhon
                Exception ashe '[Course_Semester]' could not found. Er por try er vitore diye catch e blank rekhe ata handle korsi
            6. Attendence Table Data duplication: (TeachersPanel.cs)
                Form load newar somoy "Semester" select korar maddhome "Attendence" table e data insert hoy 
                "comfirm" checkbox check korar maddhome but PROBLEM holo jotobar "comfirm" checkbox checked hoi totobar
                same ID bisisto Student insert hocche. Jar folosrutite Jokhon update dicchi ID wise tokhon ekadhik same id te "Present"
                uthe jacche jeta Attenden cound er khetre bipod jonok.
            7. Excel Workbook SaveAs() to locak disk problem  
                WorkBook theke jodi sorasori SaveAs() kori taile cell data shoho ashe file ta.
                kintu jodi Workbook ta MemoryStream e convert kore then MemoryStream theke jodi FileStream er maddhome Local disk e
                write kori taile cell data guli first open e ashe then porobortite ar ashe na kintu jodi first time ei oi file ta SaveAs kori taile hoy.
            8. Attachment Email Problem: (MailCreator.cs)
                attachment e MemoryStream theke kono data dile seta recipient er kache cell value chara jay.
                abar jodi sorasori FileStream theke dei taile thik thak jay.
            8. Sketch Upload while Splash Loading: (Splash.cs)
                ami chacchilam app ta load howar somoy e jate "FMatch" ta background e load hoye jay, kintu hocche na.
                problem hocche jokhon upload sesh hocche tokhon jokhon form ta close hocche ar Login.cs ta show hocche na.
                Partial Solve hesebe login form ta load howar por "backgroundWork" e ata diye dechi.
            9. The Sketch file which is already uploaded, uploading that sketch file in different Form again problem: (TeacherPanel.cs)
                Login.cs e already "FMatch" ta arduino te upload hoye gache, kintu Login kore TeacherPanel.cs e o FMatch er kahini,
                sekhanew abar upload hocche(Progress bar e) jeta redandent.
                
             
                
            */

            /*
             Ja ja add korar eccha ache
            Major:
            1. Teacher der Faculty add kora: Done
            2. Teacher's panel e Lecture No. add kora: Done
            3. Students der Attendence diye Mark ber kore ana
            4. Set duration set korbo mane holo Teacher akta time set korbe oi time er por automatic stopwatch off hoye jabe and
                ar kew attendence dite parbe na.


            Minor:
            ML use kore department theke Faculty Extract kora

             */

            }
        }
    }
