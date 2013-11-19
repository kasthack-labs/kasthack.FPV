using System; using System.Linq; using System.IO;using System.Windows.Forms; using System.Drawing; using System.Collections.Generic;
public class fpv : Form{
    string D; int I = 0, E = 0; bool A = false; PictureBox P; Random R = new Random();
    List<string> L = new List<string>();
    public static void Main(string[] a) { try { Application.Run(new fpv(a.Length > 0 ? a[0] : "")); } catch { } }
    public void r(int o) {try {if ( E < L.Count ) {
                P.LoadAsync( ( L = Directory.GetFiles(D).ToList() )[I = ( ( L.Count + ( I + o ) ) % L.Count )]);
                this.Text = Path.GetFileName(L[I]) + " — kasthack's Fast Photo Viewer";
            }E = 0;}catch { E++; r(o == 0 ? 1 : o); }GC.Collect();}
    private void f(object _, MouseEventArgs e) {
        bool m = this.WindowState == (FormWindowState)2;
        FormBorderStyle = (FormBorderStyle)(m ? 4 : 0);
        WindowState = (FormWindowState)(m ? 0 : 2);
        BackColor = m ? Color.White : Color.Black;}
    private void p(object _, KeyEventArgs a) {
        switch ( (int)a.KeyCode ) {
            case 13:                                        if ( !A ) r(1);  else f(null, null);break;
            case 262144: case 18: case 17:                                             A = true;break;
            case 39: case 68: case 34: case 40: case 102: case 98: case 83: case 32:       r(1);break;
            case 37: case 65: case 38: case 87: case 33: case 104: case 100:              r(-1);break;
            case 81:                                                         Application.Exit();break;
            case 122:                                                            f(null, null); break;
            case 36:case 72:                                                         I=0; r(0); break;
            case 35:case 69:                                                        I=0; r(-1); break;
            case 82:                                                               r(R.Next()); break;
            case 46: if ( ((int)MessageBox.Show("Do U really want to delete" + L[I] + "?", "Deleting", (MessageBoxButtons)4, (MessageBoxIcon)32)) == 6 ) try { File.Delete(L[I]); r(0); }catch { } this.Activate(); break;
            case 27:if ( (int)this.WindowState == 2 ) f(null, null);else Application.Exit();break;
            case 112: case 111: MessageBox.Show("FPV by kasthack v 0.8.1.\r\nKeys:\r\nD/S/v/>/Num6/Num2/Space - next photo;\r\nA/W/^/</Num8/Num4 - previous photo;\r\nHome/H - first pic in folder\r\nEnd/E - last pic\r\nF11/Alt+Enter - fullscreen;\r\nEsc - exit fullscreen;\r\nEsc-Esc/Q - exit FPV;\r\nF1/? - show this message.", "FPV:Help", (MessageBoxButtons)0, (MessageBoxIcon)64 ); break;}}
    public fpv(string a) {try {
			this.Controls.Add(P = new PictureBox() { Dock = (DockStyle)5, SizeMode = (PictureBoxSizeMode)4, BorderStyle = 0});
            P.MouseDoubleClick += f;
            KeyUp += (_, e) => { var v = (int)e.KeyCode; if ( v == 65 || v == 18 ) A = false; };
            KeyDown += p;
            MouseWheel += (_, e) => { r ( e.Delta > 0 ? -1 :1 ); };
            ClientSize = new Size(320, 220);
            L = Directory.GetFiles(D=(a=Path.GetDirectoryName(a))==""?".":a).ToList();
			MessageBox.Show("37");
        }catch { p(null, new KeyEventArgs(Keys.F1)); }
        I = L.IndexOf(a); r(0);}}
