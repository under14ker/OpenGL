using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGL
{
	public partial class Form1 : Form
	{
		private GLControl glControl;
		private float zoom = 1.0f;

		public Form1()
		{
			InitializeComponent();

			glControl = new GLControl();
			glControl.Dock = DockStyle.Fill;
			this.Controls.Add(glControl);
			glControl.Paint += GlControl_Paint;
			glControl.Load += GlControl_Load;
			glControl.MouseWheel += GlControl_MouseWheel;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void GlControl_Load(object sender, EventArgs e)
		{
			GL.ClearColor(Color.Black);
			GL.Enable(EnableCap.DepthTest);
		}

		private void GlControl_Paint(object sender, PaintEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(-zoom, zoom, -zoom, zoom,-4.0,4.0);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			GL.Rotate(20, 1.0, 0.0, 0.0);
			GL.Rotate(-20, 0.0, 1.0, 0.0);

			DrawCube();
			glControl.SwapBuffers();
		}

	

		private void GlControl_MouseWheel(object sender, MouseEventArgs e)
		{
			zoom += e.Delta > 0 ? -0.1f : 0.1f;
			glControl.Invalidate();
		}

		private void DrawCube()
		{
			GL.Begin(PrimitiveType.Quads);

			// Front face
			GL.Color3(Color.Red);
			GL.Vertex3(-1.0f, -1.0f, 1.0f);
			GL.Vertex3(1.0f, -1.0f, 1.0f);
			GL.Vertex3(1.0f, 1.0f, 1.0f);
			GL.Vertex3(-1.0f, 1.0f, 1.0f);

			// Back face
			GL.Color3(Color.Green);
			GL.Vertex3(-1.0f, -1.0f, -1.0f);
			GL.Vertex3(-1.0f, 1.0f, -1.0f);
			GL.Vertex3(1.0f, 1.0f, -1.0f);
			GL.Vertex3(1.0f, -1.0f, -1.0f);

			// Top face
			GL.Color3(Color.Blue);
			GL.Vertex3(-1.0f, 1.0f, -1.0f);
			GL.Vertex3(-1.0f, 1.0f, 1.0f);
			GL.Vertex3(1.0f, 1.0f, 1.0f);
			GL.Vertex3(1.0f, 1.0f, -1.0f);

			// Bottom face
			GL.Color3(Color.Yellow);
			GL.Vertex3(-1.0f, -1.0f, -1.0f);
			GL.Vertex3(1.0f, -1.0f, -1.0f);
			GL.Vertex3(1.0f, -1.0f, 1.0f);
			GL.Vertex3(-1.0f, -1.0f, 1.0f);

			// Right face
			GL.Color3(Color.Cyan);
			GL.Vertex3(1.0f, -1.0f, -1.0f);
			GL.Vertex3(1.0f, 1.0f, -1.0f);
			GL.Vertex3(1.0f, 1.0f, 1.0f);
			GL.Vertex3(1.0f, -1.0f, 1.0f);

			// Left face
			GL.Color3(Color.Magenta);
			GL.Vertex3(-1.0f, -1.0f, -1.0f);
			GL.Vertex3(-1.0f, -1.0f, 1.0f);
			GL.Vertex3(-1.0f, 1.0f, 1.0f);
			GL.Vertex3(-1.0f, 1.0f, -1.0f);

			GL.End();
		}
	}
}
