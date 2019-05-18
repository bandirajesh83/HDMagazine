using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Fs = System.Drawing.FontStyle;
using Gu = System.Drawing.GraphicsUnit;
using Fn = System.Drawing.Font;
using Fc = System.Drawing.Color;
using WindowsFormsApp1;

namespace HDMagazine
{
    class Class_Style
    {
        public Form FrmDisp;
        public void FrmStyle(Form frm)
        {
            FrmDisp = frm;
            FrmStl(frm);
            FrmPosition(frm);
        }
        private void FrmStl(Form frm)
        {
            frm.BackColor = System.Drawing.Color.LightGray;
            //frm.BackgroundImage = global::MMMS.Properties.Resources.logo;
            frm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDI));
            //frm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            foreach (Control c in frm.Controls)
            {
                if (c is TextBox) TxtStl((TextBox)c);
                if (c is Label) LblStl((Label)c, frm);
                if (c is Button) BtnStl((Button)c);
                if (c is ComboBox) CmbStl((ComboBox)c);
                if (c is DataGridView) GrdStl((DataGridView)c);
                if (c is DateTimePicker) DtpStl((DateTimePicker)c);
                if (c is RadioButton) RdBtnStl((RadioButton)c);
                if (c is CheckBox) ChkBtnStl((CheckBox)c);
                if (c is TabControl) TabStl((TabControl)c, frm);
                if (c is GroupBox) GBoxStl((GroupBox)c, frm);
            }
        }
        private void FrmPosition(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.HelpButton = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
        }
        private void TxtStl(TextBox Txt)
        {
            //Txt.BackColor = System.Drawing.Color.White;
            if (Txt.Name.ToString() != "TxtPayable")
                Txt.Font = new System.Drawing.Font("Verdana", 8F, Fs.Regular, Gu.Point, ((byte)(0)));
            Txt.CharacterCasing = CharacterCasing.Upper;
        }
        private void LblStl(Label Lbl, Form frm)
        {

            Lbl.BackColor = System.Drawing.Color.Transparent;

            if (Lbl.Name == "LblHdng")
            {
                Lbl.Margin = new System.Windows.Forms.Padding(0);
                Lbl.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lbl.ForeColor = System.Drawing.Color.Red;
                Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Lbl.Top = 5;
                Lbl.Left = ((frm.Width / 2) - (Lbl.Width / 2));
                //Lbl.Left = Lbl.Left - Convert.ToInt16(Lbl.Left * 0.125);
            }
            else
            {
                Lbl.ForeColor = System.Drawing.Color.Blue;
                //Lbl.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            if (Lbl.Text == "*")
            {
                Lbl.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lbl.ForeColor = System.Drawing.Color.Red;
            }
            if (Lbl.Name == "LblNote")
            {
                Lbl.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lbl.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void BtnStl(Button Btn)
        {
            Btn.BackColor = System.Drawing.Color.Lavender;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (Btn.Text.ToLower() == "&cancel" || Btn.Text.ToLower() == "cancel") Btn.CausesValidation = false;
        }
        private void CmbStl(ComboBox Cmb)
        {
            try
            {
                Cmb.Font = new System.Drawing.Font("Verdana", 8F, Fs.Regular, Gu.Point, ((byte)(0)));
                Cmb.Sorted = true;
                //Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                Cmb.DropDownStyle = ComboBoxStyle.DropDown;
                //Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                //Cmb.DropDownStyle = ComboBoxStyle.Simple;
                if (Cmb.Items.Count > 0) Cmb.SelectedIndex = 0;
            }
            catch
            { }
        }
        private void GrdStl(DataGridView Grd)
        {
            Grd.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Grd.BackgroundColor = System.Drawing.Color.DimGray;
            Grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grd.RowHeadersVisible = false;
            Grd.MultiSelect = false;
            Grd.ReadOnly = true;
            Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Grd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            Grd.ScrollBars = ScrollBars.Both;
            Grd.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            Grd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void DtpStl(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            if (dtp.Name.ToUpper().IndexOf("MNTH") > 0)
                dtp.CustomFormat = "MMMMM - yyyy";
            else
                dtp.CustomFormat = "dd-MMM-yy";
        }
        private void RdBtnStl(RadioButton rdb)
        {
            rdb.ForeColor = System.Drawing.Color.Blue;
            rdb.BackColor = System.Drawing.Color.Transparent;
            rdb.AutoSize = true;
            rdb.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void ChkBtnStl(CheckBox ChkBx)
        {
            ChkBx.ForeColor = System.Drawing.Color.Blue;
            ChkBx.BackColor = System.Drawing.Color.Transparent;
            ChkBx.AutoSize = true;
            ChkBx.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void TabStl(TabControl tab, Form frm)
        {
            foreach (Control c in tab.Controls)
            {
                if (c is TextBox) TxtStl((TextBox)c);
                if (c is Label) LblStl((Label)c, frm);
                if (c is Button) BtnStl((Button)c);
                if (c is ComboBox) CmbStl((ComboBox)c);
                if (c is DataGridView) GrdStl((DataGridView)c);
                if (c is DateTimePicker) DtpStl((DateTimePicker)c);
                if (c is GroupBox) GBoxStl((GroupBox)c, frm);
                if (c is RadioButton) RdBtnStl((RadioButton)c);
                if (c is CheckBox) ChkBtnStl((CheckBox)c);
            }
        }
        private void GBoxStl(GroupBox Gb, Form frm)
        {
            Gb.BackColor = System.Drawing.Color.Transparent;
            Gb.ForeColor = System.Drawing.Color.Red;
            foreach (Control c in Gb.Controls)
            {
                if (c is TextBox) TxtStl((TextBox)c);
                if (c is Label) LblStl((Label)c, frm);
                if (c is Button) BtnStl((Button)c);
                if (c is ComboBox) CmbStl((ComboBox)c);
                if (c is DataGridView) GrdStl((DataGridView)c);
                if (c is DateTimePicker) DtpStl((DateTimePicker)c);
                if (c is RadioButton) RdBtnStl((RadioButton)c);
                if (c is CheckBox) ChkBtnStl((CheckBox)c);
                if (c is TabControl) TabStl((TabControl)c, frm);
                if (c is GroupBox) GBoxStl((GroupBox)c, frm);
            }
        }
        public void FrmClr(Form frm)
        {
            foreach (Control c in frm.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;
                    t.Text = "";
                }
                if (c is Label)
                {
                    Label l = (Label)c;
                    if (l.Name.ToUpper() == "LBLPK")
                        l.Text = "";
                }
            }
        }
        public void ShowRpt(string RptName, string Condition, string RptHedding, string Parameters)
        { 
            FrmDispRpt crv = new FrmDispRpt(RptName, Condition, RptHedding, Parameters);
            crv.MdiParent = FrmMDI.ActiveForm;
            crv.Show();
            Application.DoEvents();
        }
    }
}
