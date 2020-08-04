using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Delegatiii
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Obavestenje obv = new Obavestenje();

			obv.Obavestavanje = obv.ObavestenjeUBox;

			Obavestenje obv2 = new Obavestenje();

			obv2.Obavestavanje = obv.ObavestenjeUFajl;

			Obavestenje obv3 = new Obavestenje();
			obv3.Obavestavanje = obv.ObavestenjeUBox;
			obv3.Obavestavanje += obv.ObavestenjeUFajl;

			

			List<Obavestenje> lst = new List<Obavestenje>();
			lst.Add(obv);
			lst.Add(obv2);
			lst.Add(obv3);

			foreach (Obavestenje oo in lst)
				oo.Obavestavanje("Test");

		}
	}

	public class Obavestenje
	{
		public delegate void DelegatZaObv(string zklj);

		public DelegatZaObv Obavestavanje;

		public void ObavestenjeUBox(string o) =>
			MessageBox.Show(o);

		public void ObavestenjeUFajl(string o) =>
			File.AppendAllText("obv.txt", o);
	}
}
