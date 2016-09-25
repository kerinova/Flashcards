using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FlashcardsLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlashcardsAndroid
{
    [Activity(Label = "Nova Flashcards", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        private const string APPLICATION_RAW_PATH = "android.resource://" + "com.kerinova.flashcards" + "/";
        private const string CARD_DATA_FILE = "CardDatabase.txt";
        private const string SEPERATOR = ";";

        private EditText txtCulture;
        private EditText txtPeriod;
        private EditText txtTitle;
        private EditText txtLocation;
        private EditText txtDate;
        private EditText txtMedium;
        private ImageView imgCardImage;

        List<string> csvDatas = new List<string>(); //cards to be processed
        List<CardData> cardDatas = new List<CardData>(); //cached cards

        private int currentCard = 0; //the current card we are on
        private int previousCard = -1; //the previous card we are on

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetTheme(Resource.Style.Theme_Custom);
            SetContentView(Resource.Layout.Main);

            txtCulture = FindViewById<EditText>(Resource.Id.txtCulture);
            txtPeriod = FindViewById<EditText>(Resource.Id.txtPeriod);
            txtTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            txtLocation = FindViewById<EditText>(Resource.Id.txtLocation);
            txtDate = FindViewById<EditText>(Resource.Id.txtDate);
            txtMedium = FindViewById<EditText>(Resource.Id.txtMedium);
            imgCardImage = FindViewById<ImageView>(Resource.Id.cardImage);
            Button btnPrev = FindViewById<Button>(Resource.Id.btnPrev);
            Button btnFlip = FindViewById<Button>(Resource.Id.btnFlip);
            Button btnNext = FindViewById<Button>(Resource.Id.btnNext);
            btnPrev.Click += BtnPrev_Click;
            btnFlip.Click += BtnFlip_Click;
            btnNext.Click += BtnNext_Click;

            LoadCards();
            ProcessCardData(0);
            DisplayCard(0);
        }

        /// <summary>
        /// Loads all lines of csv card data into a list.
        /// </summary>
        private void LoadCards()
        {
            using (var stream = Assets.Open(CARD_DATA_FILE, Android.Content.Res.Access.Streaming))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        csvDatas.Add(line);
                    }
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
            txtCulture.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtMedium.Text = string.Empty;
            txtPeriod.Text = string.Empty;
            txtTitle.Text = string.Empty;

            CardData cardData = cardDatas[cardNumber];
            string uriString = CreateImageUri(cardData.CardImagePath);
            Android.Net.Uri uri = Android.Net.Uri.Parse(uriString);
            imgCardImage.SetImageURI(uri);
        }

        private void BtnNext_Click(object sender, EventArgs e)
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

        private void BtnFlip_Click(object sender, EventArgs e)
        {
            CardData cardData = cardDatas[currentCard];
            txtCulture.Text = cardData.CardCulture;
            txtDate.Text = cardData.CardDate;
            txtLocation.Text = cardData.CardLocation;
            txtMedium.Text = cardData.CardMedium;
            txtPeriod.Text = cardData.CardPeriod;
            txtTitle.Text = cardData.CardTitle;
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (previousCard > -1)
            {
                ProcessCardData(previousCard);
                DisplayCard(previousCard);

                previousCard--;
                if (previousCard < 0) //if the previous card is 0, then go to the latest card in the list.
                {
                    previousCard = cardDatas.Count - 1;
                }
            }
        }

        private string CreateImageUri(string cardImagePath)
        {
            string uriString = APPLICATION_RAW_PATH;

            switch (cardImagePath)
            {
                case "f1":
                    {
                        uriString += Resource.Drawable.f1;
                        break;
                    }
                case "f2":
                    {
                        uriString += Resource.Drawable.f2;
                        break;
                    }
                case "f3":
                    {
                        uriString += Resource.Drawable.f3;
                        break;
                    }
                case "f4":
                    {
                        uriString += Resource.Drawable.f4;
                        break;
                    }
                case "f5":
                    {
                        uriString += Resource.Drawable.f5;
                        break;
                    }
                case "f6":
                    {
                        uriString += Resource.Drawable.f6;
                        break;
                    }
                case "f7":
                    {
                        uriString += Resource.Drawable.f7;
                        break;
                    }
                case "f8":
                    {
                        uriString += Resource.Drawable.f8;
                        break;
                    }
                case "f9":
                    {
                        uriString += Resource.Drawable.f9;
                        break;
                    }
                case "f10":
                    {
                        uriString += Resource.Drawable.f10;
                        break;
                    }
                case "f11":
                    {
                        uriString += Resource.Drawable.f11;
                        break;
                    }
                case "f12":
                    {
                        uriString += Resource.Drawable.f12;
                        break;
                    }
                case "f13":
                    {
                        uriString += Resource.Drawable.f13;
                        break;
                    }
                case "f14":
                    {
                        uriString += Resource.Drawable.f14;
                        break;
                    }
                case "f15":
                    {
                        uriString += Resource.Drawable.f15;
                        break;
                    }
                case "f16":
                    {
                        uriString += Resource.Drawable.f16;
                        break;
                    }
                case "f17":
                    {
                        uriString += Resource.Drawable.f17;
                        break;
                    }
                case "f18":
                    {
                        uriString += Resource.Drawable.f18;
                        break;
                    }
                case "f19":
                    {
                        uriString += Resource.Drawable.f19;
                        break;
                    }
                case "f20":
                    {
                        uriString += Resource.Drawable.f20;
                        break;
                    }
                case "f21":
                    {
                        uriString += Resource.Drawable.f21;
                        break;
                    }
                case "f22":
                    {
                        uriString += Resource.Drawable.f22;
                        break;
                    }
                case "f23":
                    {
                        uriString += Resource.Drawable.f23;
                        break;
                    }
                case "f24":
                    {
                        uriString += Resource.Drawable.f24;
                        break;
                    }
                case "f25":
                    {
                        uriString += Resource.Drawable.f25;
                        break;
                    }
                case "f26":
                    {
                        uriString += Resource.Drawable.f26;
                        break;
                    }
                case "f27":
                    {
                        uriString += Resource.Drawable.f27;
                        break;
                    }
                case "f28":
                    {
                        uriString += Resource.Drawable.f28;
                        break;
                    }
                case "f29":
                    {
                        uriString += Resource.Drawable.f29;
                        break;
                    }
                case "f30":
                    {
                        uriString += Resource.Drawable.f30;
                        break;
                    }
                case "f31":
                    {
                        uriString += Resource.Drawable.f31;
                        break;
                    }
            }
            return uriString;
        }
    }
}

