// This file is a part of PWSandbox ( https://github.com/yarb00/PWSandbox )
// PWSandbox is licensed under the MIT (X11) License:

/* MIT License
 *
 * Copyright (c) 2024 - 2025 yarb00
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace PWSandbox;

public enum Theme
{
	Light,
	Dark
}

public partial class MenuForm : Form
{
	private Theme currentColorTheme = Theme.Dark;

	public MenuForm()
	{
		InitializeComponent();

		appVersionLabel.Text = $"v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
	}

	private void LoadMapFile(object sender, EventArgs e)
	{
		if (mapFileLocationTextBox.Text != "")
		{
			PlayForm playForm = new PlayForm(mapFileLocationTextBox.Text);
			if (!playForm.IsDisposed) playForm.Show();
		}
		else
		{
			MessageBox.Show(
				"ERROR loading PWSandbox:"
				+ "\nmap file location is NOT specified!",
				"PWSandbox",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1
			);
			return;
		}
	}

	private void SwitchTheme(object sender, EventArgs e)
	{
		Theme newTheme = currentColorTheme == Theme.Light ? Theme.Dark : Theme.Light;

		Color backColor = Color.Transparent, foreColor = Color.Transparent;

		if (newTheme == Theme.Light)
		{
			backColor = Color.White;
			foreColor = Color.Black;
		}
		else if (newTheme == Theme.Dark)
		{
			backColor = Color.Black;
			foreColor = Color.White;
		}

		currentColorTheme = newTheme;

		BackColor = backColor;
		ForeColor = foreColor;
	}

	private void OpenAboutAppDialog(object sender, EventArgs e)
	{
		AboutForm aboutForm = new();
		aboutForm.ShowDialog();
	}
}
