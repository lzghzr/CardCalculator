using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            texLowestPrice.Text = Properties.Settings.Default.Lowest_Price.ToString();
            texExchangeRate.Text = Properties.Settings.Default.Exchange_Rate.ToString();
            butMore.Tag = false;
            CalculateAmount();
        }

        private void texLowestPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(bool)butMore.Tag)
            {
                CalculateAmount();
            }
        }

        private void texExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(bool)butMore.Tag)
            {
                CalculateAmount();
            }
        }

        private void CalculateAmount()
        {
            if (Texerror(texLowestPrice.Text) && Texerror(texExchangeRate.Text))
            {
                double AmountLd = double.Parse(texLowestPrice.Text);
                double ExchangeRateLd = double.Parse(texExchangeRate.Text);
                int AmountLi = (int)Math.Round(AmountLd * 100);
                int FeeAmountLi = CalculateFeeAmount(AmountLi);
                double uAmountLd = Math.Ceiling((AmountLi - FeeAmountLi) / ExchangeRateLd);
                AmountLd = Math.Floor(uAmountLd * ExchangeRateLd) / 100;
                texResult.Text = AmountLd.ToString();
            }
            else
            {
                texResult.Text = "error";
            }
        }

        private int CalculateFeeAmount(int Amount)
        {
            int AmountLi = Amount;
            int EstimatedAmountOfWalletFundsReceivedByOtherPartyLi = (int)((AmountLi - Properties.Settings.Default.Fee_Base) / (Properties.Settings.Default.Fee_Percent + Properties.Settings.Default.Fee_Publisher + 1));
            int[] AmountLia = new int[2];
            AmountLia = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherPartyLi);
            int iterations = 0;
            bool EverUndershot = false;
            while (AmountLia[1] != AmountLi && iterations < 10)
            {
                if (AmountLia[1] > AmountLi)
                {
                    if (EverUndershot)
                    {
                        AmountLia = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherPartyLi - 1);
                        AmountLia[0] += (AmountLi - AmountLia[1]);
                        AmountLia[1] += AmountLi;
                        break;
                    }
                    else
                    {
                        EstimatedAmountOfWalletFundsReceivedByOtherPartyLi--;
                    }
                }
                else
                {
                    EverUndershot = true;
                    EstimatedAmountOfWalletFundsReceivedByOtherPartyLi++;
                }
                AmountLia = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherPartyLi);
                iterations++;
            }
            int FeeAmount = AmountLia[0];
            return FeeAmount;
        }

        private int[] CalculateAmountToSendForDesiredReceivedAmount(int receivedAmount)
        {
            int receivedAmountLi = receivedAmount;
            int[] AmountLia = new int[2];
            int SteamFeeLi = (int)(Math.Floor(Math.Max(receivedAmountLi * Properties.Settings.Default.Fee_Publisher, 1) + Properties.Settings.Default.Fee_Base));
            int PublisherFeeLi = (int)(Math.Floor(Properties.Settings.Default.Fee_Publisher > 0 ? Math.Max(receivedAmountLi * Properties.Settings.Default.Fee_Publisher, 1) : 0));
            AmountLia[0] = SteamFeeLi + PublisherFeeLi;
            AmountLia[1] = receivedAmountLi + SteamFeeLi + PublisherFeeLi;
            return AmountLia;
        }

        private bool Texerror(string text)
        {
            bool textLb = false;
            try
            {
                double.Parse(text);
                textLb = true;
            }
            catch (Exception)
            {
                textLb = false;
            }
            return textLb;
        }

        private void butMore_Click(object sender, EventArgs e)
        {
            if ((bool)butMore.Tag)
            {
                butMore.Tag = false;
                butMore.Text = "更多";
                labLowestPrice.Text = "市场最低价格";
                labExchangeRate.Text = "当前美元汇率";
                labResult.Text = "建议收款价格";
                Properties.Settings.Default.Fee_Publisher = Texerror(texLowestPrice.Text) ? double.Parse(texLowestPrice.Text) : 0.1;
                Properties.Settings.Default.Fee_Percent = Texerror(texExchangeRate.Text) ? double.Parse(texExchangeRate.Text) : 0.05;
                Properties.Settings.Default.Fee_Base = Texerror(texResult.Text) ? int.Parse(texResult.Text) : 0;
                texResult.ReadOnly = true;
                texLowestPrice.Text = Properties.Settings.Default.Lowest_Price.ToString();
                texExchangeRate.Text = Properties.Settings.Default.Exchange_Rate.ToString();
                CalculateAmount();
            }
            else
            {
                butMore.Tag = true;
                butMore.Text = "返回";
                labLowestPrice.Text = "厂商收取费率";
                labExchangeRate.Text = "作坊收取费率";
                labResult.Text = "最低收取金额";
                Properties.Settings.Default.Lowest_Price = Texerror(texLowestPrice.Text) ? double.Parse(texLowestPrice.Text) : 0.03;
                Properties.Settings.Default.Exchange_Rate = Texerror(texExchangeRate.Text) ? double.Parse(texExchangeRate.Text) : 0;
                texResult.ReadOnly = false;
                texLowestPrice.Text = Properties.Settings.Default.Fee_Publisher.ToString();
                texExchangeRate.Text = Properties.Settings.Default.Fee_Percent.ToString();
                texResult.Text = Properties.Settings.Default.Fee_Base.ToString();
            }
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
