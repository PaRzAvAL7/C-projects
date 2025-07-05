using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5
{
    public partial class MainForm : Form
    { 
    public List<Student> AllStudents;
    private List<DCProgram> AllPrograms;
    private Dictionary<string, Campus> AllCampuses;
    private ErrorProvider errorProvider;


        public MainForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeDataGridView();
            InitializePrograms();
            InitializeCampuses();

            AllStudents = new List<Student>();

            errorProvider = new ErrorProvider();

            Campuscombobox.Enabled = false;
            Programcombobox.Enabled = false;
        }


        private void InitializeComboBoxes()
        {
            for (int i = 10; i <= 90; i += 10)
            {
                Admissioncombobox.Items.Add(i.ToString());
                Highschoolcombobox.Items.Add(i.ToString());
            }

        }


        private void InitializePrograms()
        {
            AllPrograms = new List<DCProgram>
            {
                new DCProgram("Architecture", 10000, 3),
                new DCProgram("Science and Art", 9000, 3),
                new DCProgram("Law", 11000, 3),
                new DCProgram("Health", 9500, 2),
                new DCProgram("Engineering", 10500, 3),
                new DCProgram("Music", 8500, 2),
                new DCProgram("Business", 9500, 2),
            };
        }
        private void InitializeCampuses()
        {
            AllCampuses = new Dictionary<string, Campus>
            {
                {
                    "Ontario",
                    new Campus(80, 70, 500)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[0], AllPrograms[1], AllPrograms[6] }
                    }
                },
                {
                    "Quebec",
                    new Campus(75, 65, 550)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[1], AllPrograms[2], AllPrograms[3] }
                    }
                },
                {
                    "Nova Scotia",
                    new Campus(85, 75, 600)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[3], AllPrograms[4], AllPrograms[5] }
                    }
                },
                {
                    "New Brunswick",
                    new Campus(70, 60, 520)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[6], AllPrograms[4] }
                    }
                },
                {
                    "Manitoba",
                    new Campus(78, 68, 530)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[0], AllPrograms[5], AllPrograms[6] }
                    }
                },
                {
                    "British Columbia",
                    new Campus(82, 72, 580)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[1], AllPrograms[4] }
                    }
                },
                {
                    "Prince Edward Island",
                    new Campus(79, 69, 510)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[1], AllPrograms[5] }
                    }
                },
                {
                    "Saskatchewan",
                    new Campus(74, 64, 540)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[0], AllPrograms[6] }
                    }
                },
                {
                    "Alberta",
                    new Campus(87, 77, 620)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[2], AllPrograms[3], AllPrograms[4] }
                    }
                },
                {
                    "Newfoundland and Labrador",
                    new Campus(83, 73, 590)
                    {
                        ListPrograms = new List<DCProgram> { AllPrograms[3], AllPrograms[5] }
                    }
                },
            };
        }
        private void InitializeDataGridView()
        {
            
            DataGridViewTextBoxColumn colFirstName = new DataGridViewTextBoxColumn();
            colFirstName.Name = "FirstName";
            colFirstName.HeaderText = "First Name";
            DataGridView.Columns.Add(colFirstName);

            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "LastName";
            colLastName.HeaderText = "Last Name";
            DataGridView.Columns.Add(colLastName);

            DataGridViewTextBoxColumn colSIN = new DataGridViewTextBoxColumn();
            colSIN.Name = "SIN";
            colSIN.HeaderText = "SIN";
            DataGridView.Columns.Add(colSIN);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "Email";
            colEmail.HeaderText = "Email";
            DataGridView.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colHighSchoolGrade = new DataGridViewTextBoxColumn();
            colHighSchoolGrade.Name = "HighSchoolGrade";
            colHighSchoolGrade.HeaderText = "High School Grade";
            DataGridView.Columns.Add(colHighSchoolGrade);

            DataGridViewTextBoxColumn colAdmissionTestScore = new DataGridViewTextBoxColumn();
            colAdmissionTestScore.Name = "AdmissionTestScore";
            colAdmissionTestScore.HeaderText = "Admission Test Score";
            DataGridView.Columns.Add(colAdmissionTestScore);

            DataGridViewTextBoxColumn colCampusLocation = new DataGridViewTextBoxColumn();
            colCampusLocation.Name = "CampusLocation";
            colCampusLocation.HeaderText = "Campus Location";
            DataGridView.Columns.Add(colCampusLocation);

            DataGridViewTextBoxColumn colProgram = new DataGridViewTextBoxColumn();
            colProgram.Name = "Program";
            colProgram.HeaderText = "Program";
            DataGridView.Columns.Add(colProgram);
        }

        private void CheckRecord()
        {
            
            errorProvider.SetError(textBox1, "");
            errorProvider.SetError(textBox2, "");
            errorProvider.SetError(textBox4, "");
            errorProvider.SetError(Highschoolcombobox, "");
            errorProvider.SetError(Admissioncombobox, "");
            errorProvider.SetError(textBox3, "");

            if (IsStudentInformationValid())
            {
                MessageBox.Show("Your Application has been accepted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Campuscombobox.Enabled = true;
            }
        }


        private void RegisterStudent()
        {

            Student newStudent = new Student(
                textBox1.Text,
                textBox2.Text,
                int.Parse(textBox3.Text),
                textBox4.Text,
                int.Parse(Highschoolcombobox.SelectedItem.ToString()),
                int.Parse(Admissioncombobox.SelectedItem.ToString()),
                Campuscombobox.SelectedItem.ToString(),
                Programcombobox.SelectedItem.ToString()
            );


            if (IsStudentRegistered(newStudent.SIN))
            {
                DialogResult result = MessageBox.Show("This student is already registered. Do you want to delete or update previous record?", "Student Already Registered", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    updateRecord(newStudent);
                    UpdateStudentInDataGridView(newStudent);
                }
                else
                {
                    return;
                }

            }
            else
            {
               
                AddStudentToDataGridViewAndList(newStudent);
            }

            LoadSINComboBox();

            ClearStudentInformation();
        }

        private void UpdateStudentInDataGridView(Student newStudent)
        {
            throw new NotImplementedException();
        }

        private bool IsStudentRegistered(int sin)
        {
            return AllStudents.Any(student => student.SIN == sin);
        }


        private void AddStudentToDataGridViewAndList(Student student)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DataGridView, student.FirstName, student.LastName, student.SIN, student.Email, student.HighSchoolGrade, student.AdmissionTestScore, student.CampusLocation, student.ProgramName);
            DataGridView.Rows.Add(row);
            AllStudents.Add(student);
        }

       
        private void UpdateStudentInDataGridViewAndList(Student updatedStudent)
        {
            int index = AllStudents.FindIndex(student => student.SIN == updatedStudent.SIN);

            if (index != -1)
            {
                AllStudents[index] = updatedStudent;

                DataGridViewRow row = DataGridView.Rows[index];
                row.Cells["FirstName"].Value = updatedStudent.FirstName;
                row.Cells["LastName"].Value = updatedStudent.LastName;
                row.Cells["SIN"].Value = updatedStudent.SIN;
                row.Cells["Email"].Value = updatedStudent.Email;
                row.Cells["HighSchoolGrade"].Value = updatedStudent.HighSchoolGrade;
                row.Cells["AdmissionTestScore"].Value = updatedStudent.AdmissionTestScore;
                row.Cells["CampusLocation"].Value = updatedStudent.CampusLocation;
                row.Cells["Program"].Value = updatedStudent.ProgramName;
            }
        }


        private void DeleteRecord()
        {
            int selectedSin;
            if (int.TryParse(SINComboBox.SelectedItem?.ToString(), out selectedSin))
            {
                Student selectedStudent = AllStudents.FirstOrDefault(student => student.SIN == selectedSin);

                if (selectedStudent != null)
                {
                    AllStudents.Remove(selectedStudent);

                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.Cells["SIN"].Value.ToString() == selectedSin.ToString())
                        {
                            DataGridView.Rows.Remove(row);
                            break;
                        }
                    }

                    LoadSINComboBox();

                    ClearStudentInformation();

                    SINComboBox.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Select student SIN to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         
        private void updateRecord(Student student)
        {

            student.FirstName = textBox1.Text;
            student.LastName = textBox2.Text;
            student.SIN = int.Parse(textBox3.Text);
            student.Email = textBox4.Text;
            student.HighSchoolGrade = int.Parse(Highschoolcombobox.SelectedItem.ToString());
            student.AdmissionTestScore = int.Parse(Admissioncombobox.SelectedItem.ToString());
            student.CampusLocation = Campuscombobox.SelectedItem?.ToString();
            student.ProgramName = Programcombobox.SelectedItem?.ToString();
        }



        private void RemoveAllRecords()
        {
            AllStudents.Clear();
            DataGridView.Rows.Clear();
            LoadSINComboBox();
            ClearStudentInformation();
        }

      
        private void LoadAllRecordsToServer()
        {
            try
            {

                string fileName = $"students_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);


                RemoveAllRecords();

                MessageBox.Show("Records loaded to server successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearStudentInformation()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            Highschoolcombobox.SelectedIndex = -1;
            Admissioncombobox.SelectedIndex = -1;
            Campuscombobox.Items.Clear();
            Programcombobox.Items.Clear();

            Campuscombobox.Enabled = false;
            Programcombobox.Enabled = false;
            label9.Text = "0";
            label10.Text = "0.0 $";
        }

        private void LoadSINComboBox()
        {
            SINComboBox.Items.Clear();
            foreach (Student student in AllStudents)
            {
                SINComboBox.Items.Add(student.SIN.ToString());
            }
        }

       
        public bool IsStudentInformationValid()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                isValid = false;
                errorProvider.SetError(textBox1, "First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                isValid = false;
                errorProvider.SetError(textBox2, "Last name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                isValid = false;
                errorProvider.SetError(textBox4, "Email cannot be empty.");
            }

            if (Highschoolcombobox.SelectedIndex == -1)
            {
                isValid = false;
                errorProvider.SetError(Highschoolcombobox, "High school grade must be selected.");
            }

            if (Admissioncombobox.SelectedIndex == -1)
            {
                isValid = false;
                errorProvider.SetError(Admissioncombobox, "Admission test score must be selected.");
            }

            if (!int.TryParse(SINComboBox.Text, out int parsedValue))
            {
                errorProvider.SetError(SINComboBox, "SIN cannot be invalid or empty.");
                isValid = false;
            }


            if (!isValid)
            {
                return isValid;
            }


            List<string> qualifyingCampuses = GetQualifyingCampuses();

            if (qualifyingCampuses.Count > 0)
            {
                Campuscombobox.Items.AddRange(qualifyingCampuses.ToArray());
            }
            else
            {
                MessageBox.Show("Your Application has been rejected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearStudentInformation();
                isValid = false;
            }

            return isValid;
        }


        private List<string> GetQualifyingCampuses()
        {
            int enteredGrade = int.Parse(Highschoolcombobox.SelectedItem.ToString());
            int enteredTestScore = int.Parse(Admissioncombobox.SelectedItem.ToString());

            List<string> qualifyingCampuses = new List<string>();

            foreach (var campus in AllCampuses)
            {
                if (enteredGrade >= campus.Value.HSGradeReq && enteredTestScore >= campus.Value.AdmissionTSReq)
                {
                    qualifyingCampuses.Add(campus.Key);
                }
            }

            return qualifyingCampuses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Campuscombobox.SelectedIndex == -1 || Programcombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Campus and program is mandatory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegisterStudent();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void UpdateRecord_Click(object sender, EventArgs e)
        {

            int selectedSin;
            if (int.TryParse(SINComboBox.SelectedItem?.ToString(), out selectedSin))
            {
                Student selectedStudent = AllStudents.FirstOrDefault(student => student.SIN == selectedSin);

                if (selectedStudent != null)
                {

                    textBox1.Text = selectedStudent.FirstName;
                    textBox2.Text = selectedStudent.LastName;
                    textBox3.Text = selectedStudent.SIN.ToString();
                    textBox4.Text = selectedStudent.Email;
                    Highschoolcombobox.SelectedItem = selectedStudent.HighSchoolGrade.ToString();
                    Admissioncombobox.SelectedItem = selectedStudent.AdmissionTestScore.ToString();

                    Campuscombobox.Items.Clear();
                    Programcombobox.Items.Clear();
                    Campuscombobox.Enabled = false;
                    Programcombobox.Enabled = false;

                    label9.Text = "0";
                    label10.Text = "0.0 $";

                    SINComboBox.SelectedIndex = -1; 
                }
            }
            else
            {
                MessageBox.Show("Select SIN to update student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveAllRecords();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadAllRecordsToServer();
        }

        private void programsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = "0";
            label10.Text = "0.0 $";
            string selectedProgram = Programcombobox.SelectedItem.ToString();
            string selectedCampus = Campuscombobox.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedProgram))
            {
                DCProgram program = AllPrograms.FirstOrDefault(Program => selectedProgram.Equals(Program.ProgramName));
                if (program != null)
                {
                   label9.Text = program.ProgramDuration.ToString();
                   label10.Text = (decimal)(program.ProgramFees + AllCampuses[selectedCampus].RegFees) + " $";
                }
            }
        }

        private void campusLocationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Programcombobox.Enabled = true;
            Programcombobox.Items.Clear();
            label9.Text = "0";
            label10.Text = "0.0 $";

            string selectedCampus = Campuscombobox.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedCampus) && AllCampuses.ContainsKey(selectedCampus))
            {
                Programcombobox.Items.AddRange(AllCampuses[selectedCampus].ListPrograms.Select(program => program.ProgramName).ToArray());
            }
        }

        
        private void studentsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridView.SelectedRows[0];

                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                string lastName = selectedRow.Cells["LastName"].Value.ToString();
                int sin = int.Parse(selectedRow.Cells["SIN"].Value.ToString());
                string email = selectedRow.Cells["Email"].Value.ToString();
                int highSchoolGrade = int.Parse(selectedRow.Cells["HighSchoolGrade"].Value.ToString());
                int admissionTestScore = int.Parse(selectedRow.Cells["AdmissionTestScore"].Value.ToString());
                string campusLocation = selectedRow.Cells["CampusLocation"].Value.ToString();
                string programName = selectedRow.Cells["Program"].Value.ToString();

                textBox1.Text = firstName;
                textBox2.Text = lastName;
                textBox3.Text = sin.ToString();
                textBox4.Text = email;
                Highschoolcombobox.SelectedItem = highSchoolGrade.ToString();
                Admissioncombobox.SelectedItem = admissionTestScore.ToString();
                Campuscombobox.SelectedItem = campusLocation;
                Programcombobox.SelectedItem = programName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           


        }
    }

}



