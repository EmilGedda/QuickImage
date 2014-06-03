using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace QuickImage.Model
{
	public sealed class PrintscreenCollection : IEnumerable<Printscreen>
	{
		private readonly BindingList<Printscreen> printscreens = new BindingList<Printscreen>();
		public event ListChangedEventHandler Changed;
		public int Count { get { return printscreens.Count; } }

		public Printscreen this[int number]
		{
			get { return printscreens[number]; }
		}
		private void OnChanged(object sender, ListChangedEventArgs e)
		{
			ListChangedEventHandler handler = Changed;
			if (handler != null) handler(sender, e);
		}

		public PrintscreenCollection()
		{
			printscreens.ListChanged += OnChanged;
		}

		public IEnumerator<Printscreen> GetEnumerator()
		{
			return printscreens.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return printscreens.GetEnumerator();
		}

		public void Add(Printscreen p)
		{
			printscreens.Add(p);
		}
		public void RemoveAt(int index)
		{
			printscreens[index].Delete();
			printscreens.RemoveAt(index);
		}
		public void Remove(Printscreen p)
		{
			printscreens.Remove(p);
			p.Delete();
		}
	}
}
