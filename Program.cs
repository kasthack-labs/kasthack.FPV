using System;using System.IO;using System.Windows.Forms;using System.Drawing;using Y=System.String;using System.Collections.Generic;using X=System.Int32;
class fpv:Form{
bool A,U;X B,C,T;Y D,V;Random E=new Random();PictureBox F;Y[]G;Dictionary<X,Action>H;
static void Main(Y[]a){
var o=new fpv(a.Length>0?a[0]:"")
;if(o.T!=9)Application.Run(o);}
void I(X o){try{if(C<(T=G.Length)){
F.LoadAsync((G=Directory.GetFiles(D))[B=(T+B+o)%T]);
Text=Path.GetFileName(G[B])+"— kasthack's Fast Photo Viewer";
}C=0;}catch{C++;I(o==0?1:o);}GC.Collect();}
Func<Y,Y,X,X,X>K=(a,b,c,d)=>(X)MessageBox.Show(a,b,(MessageBoxButtons)c,(MessageBoxIcon)d);
fpv(Y a){try{
Action J=()=>{FormBorderStyle=(FormBorderStyle)(T=4-(X)(WindowState=2-WindowState)*2);BackColor=T!=0?Color.White:Color.Black;},j=()=>K("FPV by kasthack v 0.9.1.\r\nKeys:\r\nD/S/v/>/Num6/Num2/Space - next photo;\r\nA/W/^/</Num8/Num4 - previous photo;\r\nHome/H - first pic in folder\r\nEnd/E - last pic\r\nF11/Alt+Enter - fullscreen;\r\nEsc - exit fullscreen;\r\nEsc-Esc/Q - exit FPV;\r\nF1/?- show this message.","FPV:Help",0,64),k=()=>{if(K("Do U really want to delete"+G[B]+"?","Deleting",4,32)==6)try{File.Delete(G[B]);I(0);}catch{}},g=()=>A=true,h=()=>I(1),i=()=>I(-1),l=()=>I((B=0)-1),m=()=>I(B=0);
H=new Dictionary<X,Action>{{68,h},{83,h},{40,h},{39,h},{98,h},{102,h},{32,h},{65,i},{87,i},{38,i},{37,i},{104,i},{100,i},{36,m},{72,m},{35,l},{69,l},{112,j},{191,j},{46,k},{81,Application.Exit},{82,()=>I(E.Next())},{27,()=>H[(X)WindowState==2?122:81]()},{122,()=>H[-1]()},{13,()=>{if(!A)I(1);else H[-1]();}},{-1,J},{262144,g},{18,g},{111,j}};
Controls.Add(F=new PictureBox{BorderStyle=0});F.SizeMode+=4;F.Dock+=5;F.MouseDoubleClick+=(x,y)=>J();
KeyUp+=(_,e)=>A&=!((T=(X)e.KeyCode)==65||T==18);
KeyDown+=(c,b)=>{if(H.TryGetValue((X)b.KeyCode,out i))i();};
MouseWheel+=(_,e)=>I(e.Delta>0?-1:1);
G=Directory.GetFiles(D=(V=Path.GetDirectoryName(a))==""?".":V);}
catch{H[111]();T=9;return;}
B=Array.IndexOf(G,a);I(0);}}