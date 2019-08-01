using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditToolBox
{
	// Token: 0x02000006 RID: 6
	internal class ScreenCapture
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000033B0 File Offset: 0x000015B0
		public static Bitmap captureScreen(int x, int y, int width, int height)
		{
			Bitmap bmp = new Bitmap(width, height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(new Point(x, y), new Point(0, 0), bmp.Size);
				g.Dispose();
			}
			return bmp;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003414 File Offset: 0x00001614
		public static Bitmap captureScreen()
		{
			Size screenSize = Screen.PrimaryScreen.Bounds.Size;
			return ScreenCapture.captureScreen(0, 0, screenSize.Width, screenSize.Height);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003450 File Offset: 0x00001650
		public static Bitmap captureControl(Control control)
		{
			IntPtr hSrce = ScreenCapture.GetWindowDC(control.Handle);
			IntPtr hDest = ScreenCapture.CreateCompatibleDC(hSrce);
			IntPtr hBmp = ScreenCapture.CreateCompatibleBitmap(hSrce, control.Width, control.Height);
			IntPtr hOldBmp = ScreenCapture.SelectObject(hDest, hBmp);
			bool flag = ScreenCapture.BitBlt(hDest, 0, 0, control.Width, control.Height, hSrce, 0, 0, (CopyPixelOperation)1087111200);
			Bitmap result;
			if (flag)
			{
				Bitmap bmp = Image.FromHbitmap(hBmp);
				ScreenCapture.SelectObject(hDest, hOldBmp);
				ScreenCapture.DeleteObject(hBmp);
				ScreenCapture.DeleteDC(hDest);
				ScreenCapture.ReleaseDC(control.Handle, hSrce);
				result = bmp;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000034E8 File Offset: 0x000016E8
		public static Bitmap captureWindowUsingPrintWindow(Form form)
		{
			return ScreenCapture.GetWindow(form.Handle);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003508 File Offset: 0x00001708
		private static Bitmap GetWindow(IntPtr hWnd)
		{
			IntPtr hscrdc = ScreenCapture.GetWindowDC(hWnd);
			Control control = Control.FromHandle(hWnd);
			IntPtr hbitmap = ScreenCapture.CreateCompatibleBitmap(hscrdc, control.Width, control.Height);
			IntPtr hmemdc = ScreenCapture.CreateCompatibleDC(hscrdc);
			ScreenCapture.SelectObject(hmemdc, hbitmap);
			ScreenCapture.PrintWindow(hWnd, hmemdc, 0u);
			Bitmap bmp = Image.FromHbitmap(hbitmap);
			ScreenCapture.DeleteDC(hscrdc);
			ScreenCapture.DeleteDC(hmemdc);
			return bmp;
		}

		// Token: 0x0600001E RID: 30
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);

		// Token: 0x0600001F RID: 31
		[DllImport("gdi32.dll")]
		private static extern IntPtr DeleteDC(IntPtr hDc);

		// Token: 0x06000020 RID: 32
		[DllImport("gdi32.dll")]
		private static extern IntPtr DeleteObject(IntPtr hDc);

		// Token: 0x06000021 RID: 33
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		// Token: 0x06000022 RID: 34
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x06000023 RID: 35
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

		// Token: 0x06000024 RID: 36
		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		// Token: 0x06000025 RID: 37
		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr ptr);

		// Token: 0x06000026 RID: 38
		[DllImport("user32.dll")]
		public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

		// Token: 0x06000027 RID: 39
		[DllImport("user32.dll")]
		private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
	}
}
