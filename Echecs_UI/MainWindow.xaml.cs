using CasEchecs_Affaires;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Echecs_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Position Origine { get; set; }
        public Position Destination { get; set; }
        private ObservableCollection<Piece> _pieces;
        public MainWindow()
        {
            Origine = new Position(1, 1);
            Destination = new Position(1, 2);
            InitializeComponent();
            this.DataContext = this;
            Echiquier.ItemsSource = _pieces = new ObservableCollection<Piece>
            {
                new Pion(CouleurPiece.Noir, new Position(0,6)),
                new Pion(CouleurPiece.Noir, new Position(1,6)),
                new Pion(CouleurPiece.Noir, new Position(2,6)),
                new Pion(CouleurPiece.Noir, new Position(3,6)),
                new Pion(CouleurPiece.Noir, new Position(4,6)),
                new Pion(CouleurPiece.Noir, new Position(5,6)),
                new Pion(CouleurPiece.Noir, new Position(6,6)),
                new Pion(CouleurPiece.Noir, new Position(7,6)),
                new Tour(CouleurPiece.Noir, new Position(0,7)),
                new Cavalier(CouleurPiece.Noir, new Position(1,7)),
                new Fou(CouleurPiece.Noir, new Position(2,7)),
                new Roi(CouleurPiece.Noir, new Position(3,7)),
                new Reine(CouleurPiece.Noir, new Position(4,7)),
                new Fou(CouleurPiece.Noir, new Position(5,7)),
                new Cavalier(CouleurPiece.Noir, new Position(6,7)),
                new Tour(CouleurPiece.Noir, new Position(7,7)),

                new Pion(CouleurPiece.Blanc, new Position(0,1)),
                new Pion(CouleurPiece.Blanc, new Position(1,1)),
                new Pion(CouleurPiece.Blanc, new Position(2,1)),
                new Pion(CouleurPiece.Blanc, new Position(3,1)),
                new Pion(CouleurPiece.Blanc, new Position(4,1)),
                new Pion(CouleurPiece.Blanc, new Position(5,1)),
                new Pion(CouleurPiece.Blanc, new Position(6,1)),
                new Pion(CouleurPiece.Blanc, new Position(7,1)),
                new Tour(CouleurPiece.Blanc, new Position(0,0)),
                new Cavalier(CouleurPiece.Blanc, new Position(1,0)),
                new Fou(CouleurPiece.Blanc, new Position(2,0)),
                new Roi(CouleurPiece.Blanc, new Position(3,0)),
                new Reine(CouleurPiece.Blanc, new Position(4,0)),
                new Fou(CouleurPiece.Blanc, new Position(5,0)),
                new Cavalier(CouleurPiece.Blanc, new Position(6,0)),
                new Tour(CouleurPiece.Blanc, new Position(7,0))
            };
        }

        private void BtnDeplacer_Click(object sender, RoutedEventArgs e)
        {
            foreach (Piece unePiece in _pieces)
                if (unePiece.Position.X == Origine.X &&
                    unePiece.Position.Y == Origine.Y)
                    unePiece.deplacer(new Position(Destination.X, Destination.Y));
            Echiquier.ItemsSource = null;
            Echiquier.ItemsSource = _pieces;
        }
    }

    public enum PieceType
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Reine,
        Roi
    }

    public enum Player
    {
        Blanc,
        Noir
    }

    public class ChessPiece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Point _Pos;
        public Point Pos
        {
            get { return this._Pos; }
            set { this._Pos = value; OnPropertyChanged("Pos"); }
        }

        private PieceType _Type;
        public PieceType Type
        {
            get { return this._Type; }
            set { this._Type = value; OnPropertyChanged("Type"); }
        }

        private Player _Player;
        public Player Player
        {
            get { return this._Player; }
            set { this._Player = value; OnPropertyChanged("Player"); }
        }
    }
}
