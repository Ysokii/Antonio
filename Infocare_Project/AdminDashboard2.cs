using Infocare_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infocare_Project_1
{
    public partial class AdminDashboard2 : Form
    {
        public AdminDashboard2()
        {
            InitializeComponent();
            ad_staffpanel.Visible = false;
            ad_docpanel.Visible = false;
            ad_patientpanel.Visible = false;
            ad_AppointmentPanel.Visible = false;

        }

        private void AdminDashboard2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500; 
            timer1.Tick += timer1_Tick;
            timer2.Interval = 500;
            timer2.Tick += timer2_Tick;
            timer3.Interval = 500;
            timer3.Tick += timer3_Tick;
            timer4.Interval = 500;
            timer4.Tick += timer4_Tick;
            LoadStaffData();
            LoadDoctorData();
        }

        public void LoadStaffData()
        {
            try
            {
                Database db = new Database();
                DataTable staffData = db.StaffList(); // Assuming a method to fetch all staff data
                StaffDataGridViewList2.DataSource = staffData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDoctorData()
        {
            try
            {
                Database db = new Database();
                DataTable doctorData = db.DoctorList(); // Assuming a method to fetch all staff data
                DoctorDataGridViewList2.DataSource = doctorData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ad_patientBtn_Click(object sender, EventArgs e)
        {
            SearchForPatientPanel.Visible = true;
            SearchForStaffPanel.Visible = false;
            SearchForDoctorPanel.Visible = false;
            SearchForAppointmentPanel.Visible = false;

            ad_patientpanel.Visible = true;
            ad_docpanel.Visible = false;
            ad_staffpanel.Visible = false;
            ad_AppointmentPanel.Visible = false;

            PatientDataGridViewList2.Visible = true;
            StaffDataGridViewList2.Visible = false;
            DoctorDataGridViewList2.Visible = false;
            AppointmentDataGridViewList2.Visible = false;

            ShowPatientList();

        }
        private void ad_StaffList_Click(object sender, EventArgs e)
        {
            SearchForStaffPanel.Visible = true;
            SearchForPatientPanel.Visible = false;
            SearchForDoctorPanel.Visible = false;
            SearchForAppointmentPanel.Visible = false;

            ad_staffpanel.Visible = true;
            ad_docpanel.Visible = false;
            ad_patientpanel.Visible = false;
            ad_AppointmentPanel.Visible = false;

            StaffDataGridViewList2.Visible = true;
            DoctorDataGridViewList2.Visible = false;
            PatientDataGridViewList2.Visible = false;
            AppointmentDataGridViewList2.Visible = false;

            ShowStaffList();
        }

        private void ad_doctor_Click(object sender, EventArgs e)
        {
            SearchForDoctorPanel.Visible = true;
            SearchForStaffPanel.Visible = false;
            SearchForPatientPanel.Visible = false;
            SearchForAppointmentPanel.Visible = false;

            ad_docpanel.Visible = true;
            ad_staffpanel.Visible = false;
            ad_patientpanel.Visible = false;
            ad_AppointmentPanel.Visible = false;

            DoctorDataGridViewList2.Visible = true;
            StaffDataGridViewList2.Visible = false;
            PatientDataGridViewList2.Visible = false;
            AppointmentDataGridViewList2.Visible = false;

            ShowDoctorList();
        }


        private void ad_appointment_Click(object sender, EventArgs e)
        {
            SearchForAppointmentPanel.Visible = true;
            SearchForDoctorPanel.Visible = false;
            SearchForStaffPanel.Visible = false;
            SearchForPatientPanel.Visible = false;


            ad_AppointmentPanel.Visible = true;
            ad_patientpanel.Visible = false;
            ad_docpanel.Visible = false;
            ad_staffpanel.Visible = false;

            AppointmentDataGridViewList2.Visible = true;
            PatientDataGridViewList2.Visible = false;
            StaffDataGridViewList2.Visible = false;
            DoctorDataGridViewList2.Visible = false;

            ShowAppointmentList();
        }

        private void AddDoctor_Click(object sender, EventArgs e)
        {
            AdminAddDoctor adminAddDoctor = new AdminAddDoctor();
            adminAddDoctor.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            AddStaff addStaffForm = new AddStaff();
            addStaffForm.FormClosed += (s, args) => LoadStaffData();
            addStaffForm.Show();
        }


        private void ShowStaffList()
        {

            Database db = new Database();
            try
            {
                DataTable staffData = db.StaffList();
                if (staffData.Rows.Count > 0)
                {
                    StaffDataGridViewList2.DataSource = staffData;
                }
                else
                {
                    MessageBox.Show("No staff data found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDoctorList()
        {

            Database db = new Database();
            try
            {
                DataTable DoctorData = db.DoctorList();
                if (DoctorData.Rows.Count > 0)
                {
                    DoctorDataGridViewList2.DataSource = DoctorData;
                }
                else
                {
                    MessageBox.Show("No Doctor data found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPatientList()
        {

            Database db = new Database();
            try
            {
                DataTable PatientData = db.PatientList();
                if (PatientData.Rows.Count > 0)
                {
                    PatientDataGridViewList2.DataSource = PatientData;
                }
                else
                {
                    MessageBox.Show("No patient data found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAppointmentList()
        {

            Database db = new Database();
            try
            {
                DataTable AppointmentData = db.AppointmentList();
                if (AppointmentData.Rows.Count > 0)
                {
                    AppointmentDataGridViewList2.DataSource = AppointmentData;
                }
                else
                {
                    MessageBox.Show("No Appointment History data found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Appointment History data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to close?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)

            {
                this.Close();
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void ad_logoutlabel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to Log Out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                AdminLogin AdminLoginForm = new AdminLogin();
                AdminLoginForm.Show();
                this.Hide();
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to Log Out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                AdminLogin AdminLoginForm = new AdminLogin();
                AdminLoginForm.Show();
                this.Hide();
            }
        }

        private void LogOutButton_Click_1(object sender, EventArgs e)
        {

        }

        private void AddDoctor_Click_1(object sender, EventArgs e)
        {
            AdminAddDoctor adminAddDoctor = new AdminAddDoctor();
            adminAddDoctor.FormClosed += (s, args) => LoadDoctorData();
            adminAddDoctor.Show();

        }

        private void pd_HomeButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to Log Out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                AdminLogin patientLoginForm = new AdminLogin();
                patientLoginForm.Show();
                this.Hide();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StaffDataGridViewList2.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["SelectCheckBox"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.ReadOnly = false;
                    }

                    checkBoxCell.Value = false;
                }
            }
        }
        private void StaffDataGridViewList2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                e.Cancel = true;
            }
        }

        private void StaffDataGridViewList2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = (bool)StaffDataGridViewList2.Rows[e.RowIndex].Cells[0].Value;


                if (isChecked)
                {
                    foreach (DataGridViewRow row in StaffDataGridViewList2.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null)
                            {
                                checkBoxCell.Value = false;
                            }
                        }
                    }
                }
            }
        }

        private void StaffDataGridViewList2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (StaffDataGridViewList2.CurrentCell is DataGridViewCheckBoxCell)
            {
                StaffDataGridViewList2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void AppointmentDataGridViewList2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                e.Cancel = true;
            }
        }

        private void AppointmentDataGridViewList2_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                e.Cancel = true;
            }
        }

        private void AppointmentDataGridViewList2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = (bool)AppointmentDataGridViewList2.Rows[e.RowIndex].Cells[0].Value;


                if (isChecked)
                {
                    foreach (DataGridViewRow row in AppointmentDataGridViewList2.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null)
                            {
                                checkBoxCell.Value = false;
                            }
                        }
                    }
                }
            }
        }

        private void AppointmentDataGridViewList2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (AppointmentDataGridViewList2.CurrentCell is DataGridViewCheckBoxCell)
            {

                AppointmentDataGridViewList2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void PatientDataGridViewList2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                e.Cancel = true;
            }
        }

        private void PatientDataGridViewList2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = (bool)PatientDataGridViewList2.Rows[e.RowIndex].Cells[0].Value;

                if (isChecked)
                {
                    foreach (DataGridViewRow row in PatientDataGridViewList2.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null)
                            {
                                checkBoxCell.Value = false;
                            }
                        }
                    }
                }
            }
        }

        private void PatientDataGridViewList2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (PatientDataGridViewList2.CurrentCell is DataGridViewCheckBoxCell)
            {
                PatientDataGridViewList2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DoctorDataGridViewList2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
                e.Cancel = true;
        }


        private void DoctorDataGridViewList2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = (bool)DoctorDataGridViewList2.Rows[e.RowIndex].Cells[0].Value;

                if (isChecked)
                {
                    foreach (DataGridViewRow row in DoctorDataGridViewList2.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null)
                            {
                                checkBoxCell.Value = false;
                            }
                        }
                    }
                }
            }
        }

        private void DoctorDataGridViewList2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DoctorDataGridViewList2.CurrentCell is DataGridViewCheckBoxCell)
            {
                DoctorDataGridViewList2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void StaffDataGridViewList2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (StaffDataGridViewList2.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                StaffDataGridViewList2.Columns[e.ColumnIndex].Name == "EditButton")
            {
                DataGridViewRow selectedRow = StaffDataGridViewList2.Rows[e.RowIndex];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    cell.ReadOnly = false;
                }

                selectedRow.Cells["EditButton"].Value = "Save";
            }
        }

        private void StaffDataGridViewList2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = StaffDataGridViewList2.Rows[e.RowIndex];

                if (row.ReadOnly == false)
                {
                    row.Tag = "Modified";
                }
            }
        }

        private void FilterPatientData()
        {
            string searchQuery = SearchForPatient.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                if (searchQuery.All(char.IsDigit))
                {
                    try
                    {
                        DataTable dataSource = (DataTable)PatientDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            // Filter for exact match of Patient ID
                            string filter = $"Convert([Patient ID], 'System.String') = '{searchQuery}'";
                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by Patient ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (searchQuery.Any(char.IsLetter))
                {
                    // If it contains letters, assume it's a first name or last name search
                    if (searchQuery.Any(char.IsDigit))
                    {
                        MessageBox.Show("Patient name cannot contain numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        DataTable dataSource = (DataTable)PatientDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            // Split the query into first and last names
                            string[] nameParts = searchQuery.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string filter = string.Empty;

                            if (nameParts.Length == 1)
                            {
                                // Search for either first or last name
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' OR [Last Name] LIKE '%{nameParts[0]}%'";
                            }
                            else if (nameParts.Length >= 2)
                            {
                                // Search for both first and last name
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' AND [Last Name] LIKE '%{nameParts[1]}%'";
                            }

                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by First and Last Name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Show a message if the input is empty or invalid
                    MessageBox.Show("Please enter a valid search query.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // If no input, reset the filter to show all data
                DataTable dataSource = (DataTable)PatientDataGridViewList2.DataSource;
                if (dataSource != null)
                {
                    dataSource.DefaultView.RowFilter = string.Empty; // Remove any filter
                }
            }
        }
        private void FilterStaffData()
        {
            string searchQuery = SearchForStaff.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                if (searchQuery.All(char.IsDigit))
                {
                    try
                    {
                        DataTable dataSource = (DataTable)StaffDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string filter = $"Convert([Staff ID], 'System.String') = '{searchQuery}'";
                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by Staff ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (searchQuery.Any(char.IsLetter))
                {
                    if (searchQuery.Any(char.IsDigit))
                    {
                        MessageBox.Show("Staff name cannot contain numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        DataTable dataSource = (DataTable)StaffDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string[] nameParts = searchQuery.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string filter = string.Empty;

                            if (nameParts.Length == 1)
                            {
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' OR [Last Name] LIKE '%{nameParts[0]}%'";
                            }
                            else if (nameParts.Length >= 2)
                            {
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' AND [Last Name] LIKE '%{nameParts[1]}%'";
                            }

                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by First and Last Name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid search query.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DataTable dataSource = (DataTable)StaffDataGridViewList2.DataSource;
                if (dataSource != null)
                {
                    dataSource.DefaultView.RowFilter = string.Empty;
                }
            }
        }
        private void FilterDoctorData()
        {
            string searchQuery = SearchForDoctor.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                if (searchQuery.All(char.IsDigit))
                {
                    try
                    {
                        DataTable dataSource = (DataTable)DoctorDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string filter = $"Convert([Doctor ID], 'System.String') = '{searchQuery}'";
                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by Staff ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (searchQuery.Any(char.IsLetter))
                {
                    if (searchQuery.Any(char.IsDigit))
                    {
                        MessageBox.Show("Staff name cannot contain numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        DataTable dataSource = (DataTable)DoctorDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string[] nameParts = searchQuery.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string filter = string.Empty;

                            if (nameParts.Length == 1)
                            {
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' OR [Last Name] LIKE '%{nameParts[0]}%'";
                            }
                            else if (nameParts.Length >= 2)
                            {
                                filter = $"[First Name] LIKE '%{nameParts[0]}%' AND [Last Name] LIKE '%{nameParts[1]}%'";
                            }

                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by First and Last Name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid search query.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DataTable dataSource = (DataTable)DoctorDataGridViewList2.DataSource;
                if (dataSource != null)
                {
                    dataSource.DefaultView.RowFilter = string.Empty;
                }
            }
        }
        private void FilterAppointmentData()
        {
            string searchQuery = SearchForAppointment.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Check if the search query is numeric to filter by Transaction ID
                if (searchQuery.All(char.IsDigit))
                {
                    try
                    {
                        DataTable dataSource = (DataTable)AppointmentDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string filter = $"Convert([Transaction ID], 'System.String') = '{searchQuery}'";
                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by Transaction ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (searchQuery.Any(char.IsLetter))
                {
                    if (searchQuery.Any(char.IsDigit))
                    {
                        MessageBox.Show("Search query cannot contain numbers if searching by name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        DataTable dataSource = (DataTable)AppointmentDataGridViewList2.DataSource;
                        if (dataSource != null)
                        {
                            string[] nameParts = searchQuery.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string filter = string.Empty;

                            if (nameParts.Length == 1)
                            {
                                // Search for a single part of the name (first or last name)
                                filter = $"[Patient Name] LIKE '%{nameParts[0]}%' OR [Doctor Name] LIKE '%{nameParts[0]}%'";
                            }
                            else if (nameParts.Length >= 2)
                            {
                                // Split the name parts into first and last names for filtering
                                string firstName = nameParts[0];
                                string lastName = nameParts[1];

                                // Filter for first and last names for both Patient and Doctor
                                filter = $"([Patient Name] LIKE '%{firstName}%' AND [Patient Name] LIKE '%{lastName}%')";
                                filter += $" OR ([Doctor Name] LIKE '%{firstName}%' AND [Doctor Name] LIKE '%{lastName}%')";
                            }

                            dataSource.DefaultView.RowFilter = filter;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while filtering data by Patient and Doctor Name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid search query.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DataTable dataSource = (DataTable)AppointmentDataGridViewList2.DataSource;
                if (dataSource != null)
                {
                    dataSource.DefaultView.RowFilter = string.Empty;
                }
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            FilterPatientData();
        }

        private void SearchForPatient_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            FilterStaffData();
        }
        private void SearchForStaff_TextChanged(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Start();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            FilterDoctorData();
        }
        private void SearchForDoctor_TextChanged(object sender, EventArgs e)
        {
            timer3.Stop();
            timer3.Start();
        }

        private void SearchForAppointment_TextChanged(object sender, EventArgs e)
        {
            timer4.Stop();
            timer4.Start();

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            FilterAppointmentData();
        }
    }




}

