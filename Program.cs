using System;using System.IO;using System.Linq;using System.Windows.Forms;using System.Drawing;using System.Collections.Generic;using Z = System.Action;
class fpv:Form{
bool A,U;int B,C,T;string D;Random E=new Random();PictureBox F;List<string> G;Dictionary<int,Z> H;
static void Main(string[] a){try{Application.Run(new fpv(a.Length>0?a[0]:""));}catch {}}
void I(int o){try{if(C<G.Count){
F.LoadAsync((G=Directory.GetFiles(D).ToList())[B=((G.Count+B+o)%G.Count)]);
Text=Path.GetFileName(G[B])+" — kasthack's Fast Photo Viewer";
}C=0;}catch{C++;I(o==0?1:o);}GC.Collect();}
void J(object _,MouseEventArgs e){
U=((int)WindowState==2);
FormBorderStyle=(FormBorderStyle)(U?4:0);
WindowState=(FormWindowState)(U?0:2);
BackColor=U?Color.White:Color.Black;}
Func<string,string,int,int,int> K=(a,b,c,d)=>(int)MessageBox.Show(a,b,(MessageBoxButtons)c,(MessageBoxIcon)d);
fpv(string a) {try{
Z j=()=>K("FPV by kasthack v 0.8.1.\r\nKeys:\r\nD/S/v/>/Num6/Num2/Space - next photo;\r\nA/W/^/</Num8/Num4 - previous photo;\r\nHome/H - first pic in folder\r\nEnd/E - last pic\r\nF11/Alt+Enter - fullscreen;\r\nEsc - exit fullscreen;\r\nEsc-Esc/Q - exit FPV;\r\nF1/?- show this message.","FPV:Help",0,64),k=()=>{if(K("Do U really want to delete "+G[B]+"?","Deleting",4,32)==6)try{File.Delete(G[B]);I(0);}catch{}},g=()=>A=true,h=()=>I(1),i=()=>I(-1),l=()=>I((B=0)-1),m=()=>I(B=0);
H=new Dictionary<int,Z>{{68,h},{83,h},{40,h},{39,h},{98,h},{102,h},{32,h},{65,i},{87,i},{38,i},{37,i},{104,i},{100,i},{36,m},{72,m},{35,l},{69,l},{112,j},{191,j},{46,k},{81,Application.Exit},{82,()=>I(E.Next())},{27,()=>H[(int)WindowState==2?122:81]()},{122,()=>H[-1]()},{13,()=>{if(!A)I(1);else H[-1]();}},{-1,()=>J(null,null)},{262144,g},{18,g}};
Controls.Add(F=new PictureBox{Dock=(DockStyle)5,SizeMode=(PictureBoxSizeMode)4,BorderStyle=0});
F.MouseDoubleClick+=J;
KeyUp+=(_,e)=>A&=!((T=(int)e.KeyCode)==65||T==18);
KeyDown+=(c,b)=>{if(H.TryGetValue((int)b.KeyCode,out i))i();};
MouseWheel+=(_,e)=>I(e.Delta>0?-1:1);
ClientSize=new Size(320,220);
G=Directory.GetFiles(D=(a=Path.GetDirectoryName(a))==""?".":a).ToList();}
catch{H[111]();Dispose();}
B=G.IndexOf(a);I(0);}}
