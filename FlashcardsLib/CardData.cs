namespace FlashcardsLib
{
    public class CardData
    {
        private string cardImagePath;
        private string cardCulture;
        private string cardPeriod;
        private string cardTitle;
        private string cardLocation;
        private string cardDate;
        private string cardMedium;

        public CardData(string cardImagePath, string cardCulture, string cardPeriod, string cardTitle, string cardLocation, string cardDate, string cardMedium)
        {
            CardImagePath = cardImagePath;
            CardCulture = cardCulture;
            CardPeriod = cardPeriod;
            CardTitle = cardTitle;
            CardLocation = cardLocation;
            CardDate = cardDate;
            CardMedium = cardMedium;
        }

        /// <summary>
        /// Gets or sets the image file path.
        /// </summary>
        public string CardImagePath
        {
            get
            {
                return cardImagePath;
            }
            set
            {
                cardImagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string CardCulture
        {
            get
            {
                return cardCulture;
            }
            set
            {
                cardCulture = value;
            }
        }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        public string CardPeriod
        {
            get
            {
                return cardPeriod;
            }
            set
            {
                cardPeriod = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string CardTitle
        {
            get
            {
                return cardTitle;
            }
            set
            {
                cardTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string CardLocation
        {
            get
            {
                return cardLocation;
            }
            set
            {
                cardLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string CardDate
        {
            get
            {
                return cardDate;
            }
            set
            {
                cardDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the medium.
        /// </summary>
        public string CardMedium
        {
            get
            {
                return cardMedium;
            }
            set
            {
                cardMedium = value;
            }
        }
    }
}
