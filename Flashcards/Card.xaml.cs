using System.Windows.Controls;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public void ClearCard()
        {
            CardCulture = string.Empty;
            CardDate = string.Empty;
            CardLocation = string.Empty;
            CardMedium = string.Empty;
            CardPeriod = string.Empty;
            CardTitle = string.Empty;
        }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string CardCulture
        {
            get
            {
                return txtCardCulture.Text;
            }
            set
            {
                txtCardCulture.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        public string CardPeriod
        {
            get
            {
                return txtCardPeriod.Text;
            }
            set
            {
                txtCardPeriod.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string CardTitle
        {
            get
            {
                return txtCardTitle.Text;
            }
            set
            {
                txtCardTitle.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string CardLocation
        {
            get
            {
                return txtCardLocation.Text;
            }
            set
            {
                txtCardLocation.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string CardDate
        {
            get
            {
                return txtCardDate.Text;
            }
            set
            {
                txtCardDate.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the medium.
        /// </summary>
        public string CardMedium
        {
            get
            {
                return txtCardMedium.Text;
            }
            set
            {
                txtCardMedium.Text = value;
            }
        }
    }
}
