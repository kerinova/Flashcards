using FlashcardsLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Flashcards
{
    public partial class MainWindow : Window
    {
        private const string CARD_DATA_FILE = "Assets/CardDatabase.txt";
        private const string SEPERATOR = ";";

        List<string> csvDatas = new List<string>(); //cards to be processed
        List<CardData> cardDatas = new List<CardData>(); //cached cards

        private int currentCard = 0; //the current card we are on
        private int previousCard = -1; //the previous card we are on

        public MainWindow()
        {
            InitializeComponent();
            LoadCards();
            ProcessCardData(0);
            DisplayCard(0);
        }

        /// <summary>
        /// Loads all lines of csv card data into a list.
        /// </summary>
        private void LoadCards()
        {
            using (var reader = new StreamReader(CARD_DATA_FILE))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    csvDatas.Add(line);
                }
            }
        }

        /// <summary>
        /// Processes a card from a csv string into a CardData object.
        /// </summary>
        /// <param name="cardNumber">The index of the csvDatas card to process.</param>
        private void ProcessCardData(int cardNumber)
        {
            string[] cardComponents = csvDatas[cardNumber].Split(new string[] { SEPERATOR }, StringSplitOptions.None);
            CardData card = new CardData(cardComponents[0], cardComponents[1], cardComponents[2], cardComponents[3], cardComponents[4], cardComponents[5], cardComponents[6]);
            cardDatas.Add(card);
        }

        /// <summary>
        /// Displays a specified card.
        /// </summary>
        /// <param name="cardNumber">The index of the cardDatas card to process.</param>
        private void DisplayCard(int cardNumber)
        {
            MainCard.ClearCard();
            CardData cardData = cardDatas[cardNumber];
            FlashImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, cardData.CardImagePath)));
        }

        /// <summary>
        /// Goes back to the previous card. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrv_Click(object sender, RoutedEventArgs e)
        {
            if(previousCard > -1)
            {
                currentCard = previousCard;
                DisplayCard(previousCard);

                previousCard--;
                if(previousCard < 0) //if the previous card is 0, then go to the latest card in the list.
                {
                    previousCard = cardDatas.Count - 1;
                    btnPrv_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Displays all of the card fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            CardData cardData = cardDatas[currentCard];
            MainCard.CardCulture = cardData.CardCulture;
            MainCard.CardDate = cardData.CardDate;
            MainCard.CardLocation = cardData.CardLocation;
            MainCard.CardMedium = cardData.CardMedium;
            MainCard.CardPeriod = cardData.CardPeriod;
            MainCard.CardTitle = cardData.CardTitle;
        }

        /// <summary>
        /// Goes to a random next card, adding it to the cache and removing it from the csv.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            if (csvDatas.Count > 0)
            {
                int nextCard = random.Next(0, csvDatas.Count);

                ProcessCardData(nextCard);

                previousCard = currentCard;
                currentCard = cardDatas.Count - 1;

                DisplayCard(currentCard);
                csvDatas.RemoveAt(nextCard);
            }
            else
            {
                int nextCard = random.Next(0, cardDatas.Count);

                previousCard = currentCard;
                currentCard = nextCard;

                DisplayCard(currentCard);
            }
        }
    }
}
