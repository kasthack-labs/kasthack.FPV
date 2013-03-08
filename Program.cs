using System; using System.IO;using System.Windows.Forms; using System.Drawing; using System.Collections.Generic;
public class fpv : Form{
    string D; int I = 0, E = 0; bool A = false; PictureBox P; Random R = new Random();
	List<string> L = new List<string>();
	public static void Main(string[] a) { try { Application.Run(new fpv(a.Length > 0 ? a[0] : "")); } catch { } }
	public void r(int o) {try {if ( E < L.Count ) {
				L.Clear();L.AddRange(Directory.GetFiles(D));
				I = ( ( L.Count + ( I + o ) ) % L.Count );
				P.LoadAsync(L[I]);
				this.Text = Path.GetFileName(L[I]) + " — kasthack's Fast Photo Viewer";
			}E = 0;}catch { E++; r(o == 0 ? 1 : o); }GC.Collect();}
	private void f(object _, MouseEventArgs e) {
		bool m = this.WindowState == FormWindowState.Maximized;
		FormBorderStyle = m ? FormBorderStyle.Sizable : FormBorderStyle.None;
		WindowState = m ? FormWindowState.Normal : FormWindowState.Maximized;
		BackColor = m ? Color.White : Color.Black;}
	private void p(object _, KeyEventArgs a) {
		switch ( a.KeyCode ) {
			case Keys.Enter:if ( !A ) r(1);  else f(null, null);break;
			case Keys.Alt: case Keys.RButton | Keys.ShiftKey: case Keys.LButton | Keys.ShiftKey:A = true;break;
			case Keys.Right: case Keys.D: case Keys.PageDown: case Keys.Down: case Keys.NumPad6: case Keys.NumPad2: case Keys.S: case Keys.Space:r(1);break;
			case Keys.Left: case Keys.A: case Keys.Up: case Keys.W: case Keys.PageUp: case Keys.NumPad8: case Keys.NumPad4:r(-1);break;
			case Keys.Q:Application.Exit();break;
			case Keys.F11:f(null, null); break;
            case Keys.Home:case Keys.H: I=0; r(0); break;
            case Keys.End:case Keys.E: I=0; r(-1); break;
            case Keys.R: r(R.Next()); break;
            case Keys.Delete: if ( MessageBox.Show("Do U really want to delete" + L[I] + "?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes ) try { File.Delete(L[I]); r(0); }catch { } this.Activate(); break;
			case Keys.Escape:if ( this.WindowState == FormWindowState.Maximized ) f(null, null);else Application.Exit();break;
			case Keys.F1: case Keys.Divide:MessageBox.Show("FPV by kasthack v 0.8.1.\r\nKeys:\r\nD/S/v/>/Num6/Num2/Space - next photo;\r\nA/W/^/</Num8/Num4 - previous photo;\r\nHome/H - first pic in folder\r\nEnd/E - last pic\r\nF11/Alt+Enter - fullscreen;\r\nEsc - exit fullscreen;\r\nEsc-Esc/Q - exit FPV;\r\nF1/? - show this message.", "FPV:Help", MessageBoxButtons.OK, MessageBoxIcon.Information);this.Activate();break;}}
	public fpv(string a) {try {
			this.Controls.Add(P = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.None });
			P.MouseDoubleClick += f;
            KeyUp += (_, e) => { if ( ( e.KeyCode == Keys.A ) || ( e.KeyCode == ( Keys.RButton | Keys.ShiftKey ) ) ) A = false; };
			KeyDown += p;
			MouseWheel += (_, e) => {r(e.Delta>0?-1:1); };
			ClientSize = new Size(320, 220);
			D = Path.GetDirectoryName(a);
			L.Clear(); L.AddRange(Directory.GetFiles(D));}
		catch { p(null, new KeyEventArgs(Keys.F1)); }
		I = L.IndexOf(a); r(0);}}
