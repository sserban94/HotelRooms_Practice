using HotelRooms_PracticeExam.Entities;
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
using System.Xml.Serialization;
using Microsoft.Data.Sqlite;

namespace HotelRooms_PracticeExam
{
    public partial class MainForm : Form
    {
        #region Attributes
        public static List<Reservation> reservations;
        public static List<Room> rooms;
        public static string connectionString = "data source=reservations.db";
        public int i = 0;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            reservations = new List<Reservation>();
            rooms = new List<Room>();

        }

        #region Methods
        public void ImportFromTxt()
        {
            using (StreamReader reader = File.OpenText("rooms.csv"))
            {
                // skip the header line
                reader.ReadLine();
                while (reader.Peek() != -1)
                {
                    string line = reader.ReadLine().ToString();
                    Room room = new Room();
                    char[] delimiterChars = { ',' };
                    string[] words = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    room.Id = int.Parse(words[0]);
                    room.Number = int.Parse(words[1]);
                    room.Beds = int.Parse(words[2]);
                    rooms.Add(room);
                }
            }
        }

        public void DisplayReservations()
        {
            lvReservations.Items.Clear();
            foreach (Reservation reservation in reservations)
            {
                ListViewItem item = new ListViewItem(reservation.Id.ToString());
                item.SubItems.Add(reservation.RoomId.ToString());
                item.SubItems.Add(reservation.CheckInDate.ToShortDateString());
                item.SubItems.Add(reservation.CheckOutDate.ToShortDateString());
                item.SubItems.Add(reservation.Persons.ToString());
                lvReservations.Items.Add(item);
                item.Tag = reservation;
            }
        }

        public void DeleteReservation()
        {
            if (lvReservations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select reservation");
                return;
            }
            foreach (ListViewItem selectedItem in lvReservations.SelectedItems)
            {
                Reservation reservation = (Reservation)selectedItem.Tag;
                reservations.Remove(reservation);
                DisplayReservations();
            }
        }

        public void EditReservation()
        {
            if (lvReservations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select reservation");
                return;
            }

            ListViewItem item = lvReservations.SelectedItems[0];
            Reservation reservation = (Reservation)item.Tag;
            NewReservationForm form = new NewReservationForm(reservation);
            if (form.ShowDialog() == DialogResult.OK)
            {
                DisplayReservations();
            }
        }

        public void ImportFromSql()
        {
            lvReservations.Items.Clear();
            string query = "SELECT * FROM Reservations";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reservation reservation = new Reservation();
                        reservation.Id = (long)reader["Id"];
                        reservation.RoomId = (long)reader["RoomId"];
                        reservation.CheckInDate = DateTime.Parse(reader["CheckInDate"].ToString());
                        reservation.CheckOutDate = DateTime.Parse(reader["CheckOutDate"].ToString());
                        reservation.Persons = int.Parse(reader["NumberOfGuests"].ToString());
                        reservations.Add(reservation);
                    }
                }
            }
            DisplayReservations();
        }

        public void ExportToSql()
        {
            string query = "INSERT INTO Reservations (Id, RoomId, CheckInDate, CheckOutDate, NumberOfGuests) " +
                "VALUES (@id, @roomId, @checkInDate, @checkOutDate, @persons);";
            foreach (Reservation reservation in reservations)
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@id", reservation.Id);
                    command.Parameters.AddWithValue("@roomId", reservation.RoomId);
                    command.Parameters.AddWithValue("@checkInDate", reservation.CheckInDate);
                    command.Parameters.AddWithValue("@checkOutDate", reservation.CheckOutDate);
                    command.Parameters.AddWithValue("@persons", reservation.Persons);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        #endregion


        #region Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            ImportFromTxt();
            //ImportFromSql();
            DisplayReservations();

        }

        private void btnNewReservationForm_Click(object sender, EventArgs e)
        {
            NewReservationForm form = new NewReservationForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DisplayReservations();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteReservation();
        }

        #endregion

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditReservation();
            DisplayReservations();
        }

        private void btnSerializeXML_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export to XML file";
            saveFileDialog.Filter = "XML file | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = File.Create(saveFileDialog.FileName))
                {
                    serializer.Serialize(stream, reservations);
                }
            }
        }

        private void btnDeserializeXML_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Reservation>));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import from XML file";
            openFileDialog.Filter = "XML file | *.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = File.OpenRead(openFileDialog.FileName))
                {
                    reservations = (List<Reservation>)serializer.Deserialize(stream);
                    DisplayReservations();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ExportToSql();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog.PageSettings = printDocument.DefaultPageSettings;

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 24);

            var pageSettings = e.PageSettings;

            // local variables - bounds of printing area rectangle
            var printAreaHeight = e.MarginBounds.Height;
            var printAreaWidth = e.MarginBounds.Width;

            // local variables - hold margins -> x, y coordinates for upper left corner of print area rectangle
            var marginLeft = e.MarginBounds.Left;
            var marginTop = e.MarginBounds.Top;

            // check if landscape was chosen and swap height and widith
            if (pageSettings.Landscape)
            {
                var temp = printAreaHeight;
                printAreaHeight = printAreaWidth;
                printAreaWidth = temp;
            }

            const int rowHeight = 40;
            var columnWidth = printAreaWidth / 5;

            // implementing StringFormat which encapsulated text layout (alignment, line spacing), display manipulation and OpenType features
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.Trimming = StringTrimming.EllipsisCharacter;

            var currentY = marginTop;
            
            while(i < reservations.Count)
            {
                //reseting horizontal drawing coordinate
                var currentX = marginLeft;

                //Draw border of cell
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    reservations[i].Id.ToString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    reservations[i].RoomId.ToString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth*1.25f,
                    rowHeight);
                e.Graphics.DrawString(
                    reservations[i].CheckInDate.ToShortDateString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += (int)(columnWidth * 1.25);

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth * 1.25f,
                    rowHeight);
                e.Graphics.DrawString(
                    reservations[i].CheckOutDate.ToShortDateString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += (int)(columnWidth * 1.25);

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    reservations[i].Persons.ToString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += columnWidth;

                i++;
                //Update vertical drawing coordinate
                currentY += rowHeight;

                // HasMorePages tells the printing module whether anothehr PrintPage event should take place/be fired
                if (currentY + rowHeight > printAreaHeight)
                {
                    e.HasMorePages = true;
                    break;
                }
            }
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i = 0;
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Error occured");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
