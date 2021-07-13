
namespace HotelRooms_PracticeExam
{
    partial class NewReservationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbNoOfGuests = new System.Windows.Forms.ComboBox();
            this.lbRoom = new System.Windows.Forms.ListBox();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbOrderCriteria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNoOfGuests
            // 
            this.cbNoOfGuests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoOfGuests.FormattingEnabled = true;
            this.cbNoOfGuests.Location = new System.Drawing.Point(802, 110);
            this.cbNoOfGuests.Name = "cbNoOfGuests";
            this.cbNoOfGuests.Size = new System.Drawing.Size(212, 39);
            this.cbNoOfGuests.TabIndex = 9;
            this.cbNoOfGuests.Validating += new System.ComponentModel.CancelEventHandler(this.cbNoOfGuests_Validating);
            this.cbNoOfGuests.Validated += new System.EventHandler(this.cbNoOfGuests_Validated);
            // 
            // lbRoom
            // 
            this.lbRoom.FormattingEnabled = true;
            this.lbRoom.ItemHeight = 31;
            this.lbRoom.Location = new System.Drawing.Point(802, 199);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(212, 128);
            this.lbRoom.TabIndex = 0;
            this.lbRoom.Validating += new System.ComponentModel.CancelEventHandler(this.lbRoom_Validating);
            this.lbRoom.Validated += new System.EventHandler(this.lbRoom_Validated);
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(802, 419);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(463, 38);
            this.dtpCheckInDate.TabIndex = 1;
            this.dtpCheckInDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpCheckInDate_Validating);
            this.dtpCheckInDate.Validated += new System.EventHandler(this.dtpCheckInDate_Validated);
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(802, 535);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(463, 38);
            this.dtpCheckOutDate.TabIndex = 2;
            this.dtpCheckOutDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpCheckOutDate_Validating);
            this.dtpCheckOutDate.Validated += new System.EventHandler(this.dtpCheckOutDate_Validated);
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddReservation.Location = new System.Drawing.Point(802, 624);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(173, 81);
            this.btnAddReservation.TabIndex = 3;
            this.btnAddReservation.Text = "OK";
            this.btnAddReservation.UseVisualStyleBackColor = true;
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose Room";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Check-In Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Check-Out Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "No of Guests";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cbOrderCriteria
            // 
            this.cbOrderCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderCriteria.FormattingEnabled = true;
            this.cbOrderCriteria.Location = new System.Drawing.Point(1075, 199);
            this.cbOrderCriteria.Name = "cbOrderCriteria";
            this.cbOrderCriteria.Size = new System.Drawing.Size(246, 39);
            this.cbOrderCriteria.TabIndex = 10;
            this.cbOrderCriteria.SelectedIndexChanged += new System.EventHandler(this.cbOrderCriteria_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1069, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Order rooms by";
            // 
            // NewReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1367, 867);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbOrderCriteria);
            this.Controls.Add(this.cbNoOfGuests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddReservation);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.lbRoom);
            this.Name = "NewReservationForm";
            this.Text = "NewReservationForm";
            this.Load += new System.EventHandler(this.NewReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNoOfGuests;
        private System.Windows.Forms.ListBox lbRoom;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbOrderCriteria;
        private System.Windows.Forms.Label label5;
    }
}