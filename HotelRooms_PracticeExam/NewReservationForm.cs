using HotelRooms_PracticeExam.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelRooms_PracticeExam
{
    public partial class NewReservationForm : Form
    {
        #region Attributes
        public static long reservationId = 0;
        private Reservation reservationForEditing;
        #endregion

        #region Ctor
        
        
        public NewReservationForm()
        {
            InitializeComponent();
            DisplayNumberOfGuests();
            DisplayRoomNumber();
            DisplayOrderCriteria();
        }

        public NewReservationForm(Reservation reservation)
        {
            InitializeComponent();
            DisplayNumberOfGuests();
            DisplayRoomNumber();
            DisplayOrderCriteria();
            this.reservationForEditing = reservation;
        }

        #endregion

        #region Methods
        private void DisplayNumberOfGuests()
        {
            int max = 0;
            foreach (Room room in MainForm.rooms)
            {
                if (room.Beds > max)
                {
                    max = room.Beds;
                }
            }
            for (int i = 0; i < max; i++)
            {
                cbNoOfGuests.Items.Add(i+1);
            }
        }

        private void DisplayRoomNumber()
        {
            foreach (Room room in MainForm.rooms)
            {
                lbRoom.Items.Add(room.Number);
            }
        }

        private void MakeReservation()
        {
            if (reservationForEditing == null)
            {
                Reservation reservation = new Reservation();
                reservation.Persons = int.Parse(cbNoOfGuests.SelectedItem.ToString());
                reservation.CheckInDate = dtpCheckInDate.Value;
                reservation.CheckOutDate = dtpCheckOutDate.Value;
                foreach (Room room in MainForm.rooms)
                {
                    if (room.Number == int.Parse(lbRoom.SelectedItem.ToString()))
                    {
                        reservation.RoomId = room.Id;
                        break;
                    }
                }
                reservation.Id = reservationId++;
                MainForm.reservations.Add(reservation);
            }
            else
            {
                reservationForEditing.Persons = int.Parse(cbNoOfGuests.SelectedItem.ToString());
                reservationForEditing.CheckInDate = dtpCheckInDate.Value;
                reservationForEditing.CheckOutDate = dtpCheckOutDate.Value;
                foreach (Room room in MainForm.rooms)
                {
                    if (room.Number == int.Parse(lbRoom.SelectedItem.ToString()))
                    {
                        reservationForEditing.RoomId = room.Id;
                        break;
                    }
                }
            }
        }

        void DisplayOrderCriteria()
        {
            cbOrderCriteria.Items.Add("Number of beds");
        }

        void OrderRoomsByCriteria()
        {
            if (cbOrderCriteria.SelectedItem.ToString() == "Number of beds")
            {
                lbRoom.Items.Clear();
                List<Room> sortedRooms = new List<Room>();
                sortedRooms.AddRange(MainForm.rooms);
                //sortedRooms.Sort();
                RoomDescCompare descCompare = new RoomDescCompare();
                sortedRooms.Sort(descCompare);
                    
                foreach (Room room in sortedRooms)
                {
                    lbRoom.Items.Add(room.Number);
                }
            }
        }
        





        #endregion

        #region Events

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show(
                    "Validations failed. Check again",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MakeReservation();
            this.Close();
        }


        private void cbNoOfGuests_Validating(object sender, CancelEventArgs e)
        {
            if (cbNoOfGuests.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNoOfGuests, "Must select number of guests");
                e.Cancel = true;
            }
        }

        private void cbNoOfGuests_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(cbNoOfGuests, null);
        }
        


        private void lbRoom_Validating(object sender, CancelEventArgs e)
        {
            if (lbRoom.SelectedIndex == -1)
            {
                errorProvider.SetError(lbRoom, "No room selected");
                e.Cancel = true;
            }
            else
            {
                foreach (Room room in MainForm.rooms)
                {
                    if (room.Number == int.Parse(lbRoom.SelectedItem.ToString()))
                    {
                        if (cbNoOfGuests.SelectedIndex == -1)
                        {
                            errorProvider.SetError(lbRoom, "Choose number of guests");
                            e.Cancel = true;
                            break;
                        }
                        else if (room.Beds < int.Parse(cbNoOfGuests.SelectedItem.ToString()))
                        {
                            errorProvider.SetError(lbRoom, "Number of guests exceeds number of beds.\n" +
                                "Choose another hotel room");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        private void lbRoom_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(lbRoom, null);
        }

        

        private void dtpCheckInDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpCheckInDate.Value.Date < DateTime.Now.Date)
            {
                errorProvider.SetError(dtpCheckInDate, "Invalid date");
                e.Cancel = true;
            }
        }

        private void dtpCheckInDate_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dtpCheckInDate, null);
        }

        private void dtpCheckOutDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpCheckOutDate.Value < DateTime.Now)
            {
                errorProvider.SetError(dtpCheckOutDate, "Invalid date. Select present or future date");
                e.Cancel = true;
            }
            else if (dtpCheckOutDate.Value < dtpCheckInDate.Value)
            {
                errorProvider.SetError(dtpCheckOutDate, "Invalid date. Check-Out must be after Check-In");
                e.Cancel = true;
            }
        }

        private void dtpCheckOutDate_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dtpCheckOutDate, null);
        }
        #endregion

        private void NewReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void cbOrderCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderRoomsByCriteria();
        }
    }
}
