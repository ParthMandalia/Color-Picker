﻿using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Porrey.Controls.ColorPicker
{
	[TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	[TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[TemplateVisualState(Name = "PointerOver", GroupName = "CommonStates")]
	[TemplateVisualState(Name = "Pressed", GroupName = "CommonStates")]
	[TemplatePart(Name = "PART_Rotary", Type = typeof(Border))]
	[TemplatePart(Name = "PART_Center", Type = typeof(Border))]
	[TemplatePart(Name = "PART_Indicator", Type = typeof(Polygon))]
	[TemplatePart(Name = "PART_Content", Type = typeof(Polygon))]
	public class ColorPickerWheel : ContentControl
	{
		public ColorPickerWheel()
		{
			this.DefaultStyleKey = typeof(ColorPickerWheel);
			this.IsEnabledChanged += this.HueColorPicker_IsEnabledChanged;
		}

		#region Dependency Properties
		public static readonly DependencyProperty OuterDiameterProperty = DependencyProperty.Register("OuterDiameter", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(300.0, new PropertyChangedCallback(OnOuterDiameterPropertyChanged)));
		public static readonly DependencyProperty InnerDiameterProperty = DependencyProperty.Register("InnerDiameter", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(150.0, new PropertyChangedCallback(OnInnerDiameterPropertyChanged)));
		public static readonly DependencyProperty CenterBackgroundProperty = DependencyProperty.Register("CenterBackground", typeof(Brush), typeof(ColorPickerWheel), new PropertyMetadata(null, new PropertyChangedCallback(OnCenterBackgroundPropertyChanged)));
		public static readonly DependencyProperty IndicatorBackgroundProperty = DependencyProperty.Register("IndicatorBackground", typeof(Brush), typeof(ColorPickerWheel), new PropertyMetadata(null, new PropertyChangedCallback(OnIndicatorBackgroundPropertyChanged)));
		public static readonly DependencyProperty IndicatorScaleProperty = DependencyProperty.Register("IndicatorScale", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(1.0, new PropertyChangedCallback(OnIndicatorScalePropertyChanged)));
		public static readonly DependencyProperty IndicatorOffsetProperty = DependencyProperty.Register("IndicatorOffset", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(0, new PropertyChangedCallback(OnIndicatorOffsetPropertyChanged)));
		public static readonly DependencyProperty RotationProperty = DependencyProperty.Register("Rotation", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(0.0, new PropertyChangedCallback(OnRotationPropertyChanged)));
		public static readonly DependencyProperty HueProperty = DependencyProperty.Register("Hue", typeof(int), typeof(ColorPickerWheel), new PropertyMetadata(0, new PropertyChangedCallback(OnHuePropertyChanged)));
		public static readonly DependencyProperty SaturationProperty = DependencyProperty.Register("Saturation", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(1.0, new PropertyChangedCallback(OnSaturationPropertyChanged)));
		public static readonly DependencyProperty LuminosityProperty = DependencyProperty.Register("Luminosity", typeof(double), typeof(ColorPickerWheel), new PropertyMetadata(.5, new PropertyChangedCallback(OnLuminosityPropertyChanged)));
		public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(SolidColorBrush), typeof(ColorPickerWheel), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)), new PropertyChangedCallback(OnSelectedColorPropertyChanged)));
		public static readonly DependencyProperty IsInertiaEnabledProperty = DependencyProperty.Register("IsInertiaEnabled", typeof(bool), typeof(ColorPickerWheel), new PropertyMetadata(true, new PropertyChangedCallback(OnIsInertiaEnabledPropertyChanged)));
		#endregion

		#region Public Events
		public event EventHandler<ValueChangedEventArgs<double>> OuterDiameterChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> InnerDiameterChanged = null;
		public event EventHandler<ValueChangedEventArgs<Brush>> CenterBackgroundChanged = null;
		public event EventHandler<ValueChangedEventArgs<Brush>> IndicatorBackgroundChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> IndicatorScaleChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> IndicatorOffsetChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> RotationChanged = null;
		public event EventHandler<ValueChangedEventArgs<int>> HueChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> SaturationChanged = null;
		public event EventHandler<ValueChangedEventArgs<double>> LuminosityChanged = null;
		public event EventHandler<ValueChangedEventArgs<SolidColorBrush>> SelectedColorChanged = null;
		public event EventHandler<ValueChangedEventArgs<bool>> IsInertiaEnabledChanged = null;

		protected virtual void RaiseOuterDiameterChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnOuterDiameterChangedEvent(this, e);
			this.OuterDiameterChanged?.Invoke(this, e);
		}

		protected virtual void OnOuterDiameterChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{
		}

		protected virtual void RaiseInnerDiameterChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnInnerDiameterChangedEvent(this, e);
			this.InnerDiameterChanged?.Invoke(this, e);
		}

		protected virtual void OnInnerDiameterChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{
		}

		protected virtual void RaiseCenterBackgroundChangedEvent(Brush previousValue, Brush newValue)
		{
			ValueChangedEventArgs<Brush> e = new ValueChangedEventArgs<Brush>(previousValue, newValue);
			this.OnCenterBackgroundChangedEvent(this, e);
			this.CenterBackgroundChanged?.Invoke(this, e);
		}

		protected virtual void OnCenterBackgroundChangedEvent(object sender, ValueChangedEventArgs<Brush> e)
		{
		}

		protected virtual void RaiseIndicatorBackgroundChangedEvent(Brush previousValue, Brush newValue)
		{
			ValueChangedEventArgs<Brush> e = new ValueChangedEventArgs<Brush>(previousValue, newValue);
			this.OnIndicatorBackgroundChangedEvent(this, e);
			this.IndicatorBackgroundChanged?.Invoke(this, e);
		}

		protected virtual void OnIndicatorBackgroundChangedEvent(object sender, ValueChangedEventArgs<Brush> e)
		{
		}

		protected virtual void RaiseIndicatorScaleChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnIndicatorScaleChangedEvent(this, e);
			this.IndicatorScaleChanged?.Invoke(this, e);
		}

		protected virtual void OnIndicatorScaleChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{

		}

		protected virtual void RaiseIndicatorOffsetChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnIndicatorOffsetChangedEvent(this, e);
			this.IndicatorOffsetChanged?.Invoke(this, e);
		}

		protected virtual void OnIndicatorOffsetChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{
		}

		protected virtual void RaiseRotationChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnRotationChangedEvent(this, e);
			this.RotationChanged?.Invoke(this, e);
		}

		protected virtual void OnRotationChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{
		}

		protected virtual void RaiseHueChangedEvent(int previousValue, int newValue)
		{
			ValueChangedEventArgs<int> e = new ValueChangedEventArgs<int>(previousValue, newValue);
			this.OnHueChangedEvent(this, e);
			this.HueChanged?.Invoke(this, e);
		}

		protected virtual void OnHueChangedEvent(object sender, ValueChangedEventArgs<int> e)
		{
		}

		protected virtual void RaiseSaturationChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnSaturationChangedEvent(this, e);
			this.SaturationChanged?.Invoke(this, e);
		}

		protected virtual void OnSaturationChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{
		}

		protected virtual void RaiseLuminosityChangedEvent(double previousValue, double newValue)
		{
			ValueChangedEventArgs<double> e = new ValueChangedEventArgs<double>(previousValue, newValue);
			this.OnLuminosityChangedEvent(this, e);
			this.LuminosityChanged?.Invoke(this, e);
		}

		protected virtual void OnLuminosityChangedEvent(object sender, ValueChangedEventArgs<double> e)
		{

		}

		protected virtual void RaiseSelectedColorChangedEvent(SolidColorBrush previousValue, SolidColorBrush newValue)
		{
			ValueChangedEventArgs<SolidColorBrush> e = new ValueChangedEventArgs<SolidColorBrush>(previousValue, newValue);
			this.OnSelectedColorChangedEvent(this, e);
			this.SelectedColorChanged?.Invoke(this, e);
		}

		protected virtual void OnSelectedColorChangedEvent(object sender, ValueChangedEventArgs<SolidColorBrush> e)
		{
		}

		protected virtual void RaiseIsInertiaEnabledChangedEvent(bool previousValue, bool newValue)
		{
			ValueChangedEventArgs<bool> e = new ValueChangedEventArgs<bool>(previousValue, newValue);
			this.OnIsInertiaEnabledChangedEvent(this, e);
			this.IsInertiaEnabledChanged?.Invoke(this, e);
		}

		protected virtual void OnIsInertiaEnabledChangedEvent(object sender, ValueChangedEventArgs<bool> e)
		{
		}
		#endregion

		#region Dependency Property Change Callbacks
		private static void OnOuterDiameterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				if (instance.OuterDiameter > instance.InnerDiameter)
				{
					instance.RaiseOuterDiameterChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
				}
				else
				{
					throw new ArgumentOutOfRangeException("OuterDiameter", "Outer Diameter must be a greater than Inner Diameter.");
				}
			}
		}

		private static void OnInnerDiameterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				if (instance.InnerDiameter < instance.OuterDiameter)
				{
					instance.RaiseInnerDiameterChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
				}
				else
				{
					throw new ArgumentOutOfRangeException("InnerDiameter", "Inner Diameter must be a less than Outer Diameter.");
				}
			}
		}

		private static void OnCenterBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.RaiseCenterBackgroundChangedEvent((Brush)e.OldValue, (Brush)e.NewValue);
			}
		}

		private static void OnIndicatorBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.RaiseIndicatorBackgroundChangedEvent((Brush)e.OldValue, (Brush)e.NewValue);
			}
		}

		private static void OnIndicatorScalePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.RaiseIndicatorScaleChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
			}
		}

		private static void OnIndicatorOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.RaiseIndicatorOffsetChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
			}
		}

		private static void OnRotationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				double rotation = Convert.ToDouble(e.NewValue);
				instance.RotateTransform.Angle = rotation % 360;
				instance.Hue = rotation.GetHueFromRotation();

				instance.RaiseRotationChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
			}
		}

		private static void OnHuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				if (instance.Hue >= 0 && instance.Hue <= 360)
				{
					if (instance.RotateTransform != null)
					{
						instance.RotateTransform.Angle = instance.Hue.GetRotationFromHue();
						instance.ApplySelectedColor();
						instance.RaiseHueChangedEvent(Convert.ToInt32(e.OldValue), Convert.ToInt32(e.NewValue));
					}
				}
				else
				{
					throw new ArgumentOutOfRangeException("Hue", "Hue must be a value from 0 to 360.");
				}
			}
		}

		private static void OnSaturationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				if (instance.Saturation >= 0 && instance.Saturation <= 1.0)
				{
					instance.ApplySelectedColor();
					instance.RaiseSaturationChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
				}
				else
				{
					throw new ArgumentOutOfRangeException("Saturation", "Saturation must be a value from 0 to 1.0.");
				}
			}
		}

		private static void OnLuminosityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				if (instance.Luminosity >= 0 && instance.Luminosity <= 1.0)
				{
					instance.ApplySelectedColor();
					instance.RaiseLuminosityChangedEvent(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
				}
				else
				{
					throw new ArgumentOutOfRangeException("Luminosity", "Luminosity must be a value from 0 to 1.0.");
				}
			}
		}

		private static void OnIsInertiaEnabledPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.SetManipulationMode();
				instance.RaiseIsInertiaEnabledChangedEvent(Convert.ToBoolean(e.OldValue), Convert.ToBoolean(e.NewValue));
			}
		}

		private static void OnSelectedColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ColorPickerWheel instance)
			{
				instance.RaiseSelectedColorChangedEvent((SolidColorBrush)e.OldValue, (SolidColorBrush)e.NewValue);
			}
		}
		#endregion

		#region Control Event Handlers
		protected override void OnApplyTemplate()
		{
			if (this.GetTemplateChild("PART_Rotary") is Border rotary)
			{
				this.Rotary = rotary;

				this.Rotary.ManipulationStarting += this.Rotary_ManipulationStarting;
				this.Rotary.ManipulationStarted += this.Rotary_ManipulationStarted;
				this.Rotary.ManipulationDelta += this.Rotary_ManipulationDelta;
				this.Rotary.Tapped += this.Rotary_Tapped;
				this.SetManipulationMode();

				this.RotateTransform = ((RotateTransform)this.Rotary.RenderTransform);
				this.RotateTransform.Angle = this.Hue.GetRotationFromHue();
				this.GradientBrush = this.Rotary.Background;

				this.ApplySelectedColor();
			}

			if (this.GetTemplateChild("PART_Center") is Border center)
			{
				center.ManipulationMode = ManipulationModes.None;
				center.Tapped += this.Center_Tapped;
			}

			if (this.GetTemplateChild("PART_Indicator") is Polygon Indicator)
			{
				this.IndicatorTransform = (CompositeTransform)Indicator.RenderTransform;
				this.IndicatorTransform.ScaleX = this.IndicatorScale;
				this.IndicatorTransform.ScaleY = this.IndicatorScale;
				this.IndicatorTransform.TranslateY = this.IndicatorOffset;
			}

			// ***
			// *** Set initial state
			// ***
			if (this.IsEnabled)
			{
				VisualStateManager.GoToState(this, "Normal", true);
			}
			else
			{
				VisualStateManager.GoToState(this, "Disabled", true);
			}

			base.OnApplyTemplate();

			// ***
			// *** Initialize the selected color.
			// ***
			this.ApplySelectedColor();
		}

		private void Rotary_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
		{
			FrameworkElement element = sender as FrameworkElement;
			e.Pivot = new ManipulationPivot(element.Center(), element.ActualWidth / 2.0);
		}

		private void Rotary_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
		{
			this.Rotation += e.Cumulative.Rotation;
			e.Handled = true;
		}

		private void Rotary_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
		{
			this.Rotation += e.Delta.Rotation;
			e.Handled = true;
		}

		private void Rotary_Tapped(object sender, TappedRoutedEventArgs e)
		{
			FrameworkElement element = sender as FrameworkElement;

			Point point = e.GetPosition(element);
			Point center = element.Center();

			// ***
			// *** The rotation angle is the opposite of the angle as
			// *** calculated in the euclidean space.
			// ***
			double rotation = center.GetAngle(point).ToDegrees().ToRotation();

			this.Rotation = rotation;
		}

		private void Center_Tapped(object sender, TappedRoutedEventArgs e)
		{
			// ***
			// *** Don't allow tapping the center to change the color.
			// ***
			e.Handled = true;
		}

		private bool _pointerEntered = false;
		protected override void OnPointerEntered(PointerRoutedEventArgs e)
		{
			_pointerEntered = true;
			VisualStateManager.GoToState(this, "PointerOver", true);
			base.OnPointerEntered(e);
		}

		protected override void OnPointerExited(PointerRoutedEventArgs e)
		{
			_pointerEntered = false;
			VisualStateManager.GoToState(this, "Normal", true);
			base.OnPointerExited(e);
		}

		protected override void OnPointerPressed(PointerRoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "Pressed", true);
			base.OnPointerPressed(e);
		}

		protected override void OnPointerReleased(PointerRoutedEventArgs e)
		{
			if (_pointerEntered)
			{
				VisualStateManager.GoToState(this, "PointerOver", true);
			}
			else
			{
				VisualStateManager.GoToState(this, "Normal", true);
			}

			base.OnPointerReleased(e);
		}

		private void HueColorPicker_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is bool enabled)
			{
				if (enabled)
				{
					VisualStateManager.GoToState(this, "Normal", true);
				}
				else
				{
					VisualStateManager.GoToState(this, "Disabled", true);
				}
			}
		}
		#endregion

		#region Internal Methods & Properties
		protected ManipulationModes ManipulationWithInertia { get; } = ManipulationModes.TranslateInertia | ManipulationModes.TranslateX | ManipulationModes.TranslateY | ManipulationModes.Rotate | ManipulationModes.RotateInertia;
		protected ManipulationModes ManipulationWithoutInertia { get; } = ManipulationModes.TranslateX | ManipulationModes.TranslateY | ManipulationModes.Rotate;

		protected Border Rotary { get; set; }
		protected RotateTransform RotateTransform { get; set; }
		protected Brush GradientBrush { get; set; }
		protected CompositeTransform IndicatorTransform { get; set; }

		protected void SetManipulationMode()
		{
			if (this.IsInertiaEnabled)
			{
				this.Rotary.ManipulationMode = this.ManipulationWithInertia;
			}
			else
			{
				this.Rotary.ManipulationMode = this.ManipulationWithoutInertia;
			}
		}

		protected void ApplySelectedColor()
		{
			this.SelectedColor = new SolidColorBrush(Microsoft.Toolkit.Uwp.Helpers.ColorHelper.FromHsl(this.Hue, this.Saturation, this.Luminosity));
		}
		#endregion

		#region Public Methods & Properties
		public double OuterDiameter
		{
			get
			{
				return (double)GetValue(OuterDiameterProperty);
			}
			set
			{
				SetValue(OuterDiameterProperty, value);
			}
		}

		public double InnerDiameter
		{
			get
			{
				return (double)GetValue(InnerDiameterProperty);
			}
			set
			{
				SetValue(InnerDiameterProperty, value);
			}
		}

		public Brush CenterBackground
		{
			get
			{
				return (Brush)GetValue(CenterBackgroundProperty);
			}
			set
			{
				SetValue(CenterBackgroundProperty, value);
			}
		}

		public Brush IndicatorBackground
		{
			get
			{
				return (Brush)GetValue(IndicatorBackgroundProperty);
			}
			set
			{
				SetValue(IndicatorBackgroundProperty, value);
			}
		}

		public double Rotation
		{
			get
			{
				return (double)GetValue(RotationProperty);
			}
			set
			{
				SetValue(RotationProperty, value);
			}
		}

		public int Hue
		{
			get
			{
				return (int)GetValue(HueProperty);
			}
			set
			{
				SetValue(HueProperty, value);
			}
		}

		public double Saturation
		{
			get
			{
				return (double)GetValue(SaturationProperty);
			}
			set
			{
				SetValue(SaturationProperty, value);
			}
		}

		public double Luminosity
		{
			get
			{
				return (double)GetValue(LuminosityProperty);
			}
			set
			{
				SetValue(LuminosityProperty, value);
			}
		}

		public SolidColorBrush SelectedColor
		{
			get
			{
				return (SolidColorBrush)GetValue(SelectedColorProperty);
			}
			private set
			{
				SetValue(SelectedColorProperty, value);
			}
		}

		public double IndicatorScale
		{
			get
			{
				return (double)GetValue(IndicatorScaleProperty);
			}
			set
			{
				SetValue(IndicatorScaleProperty, value);
			}
		}

		public double IndicatorOffset
		{
			get
			{
				return (double)GetValue(IndicatorOffsetProperty);
			}
			set
			{
				SetValue(IndicatorOffsetProperty, value);
			}
		}

		public bool IsInertiaEnabled
		{
			get
			{
				return (bool)GetValue(IsInertiaEnabledProperty);
			}
			set
			{
				SetValue(IsInertiaEnabledProperty, value);
			}
		}

		public void SetSelectedColor(Color color)
		{
			Microsoft.Toolkit.Uwp.HslColor hsl = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToHsl(color);
			this.Hue = (int)hsl.H;
			this.Saturation = hsl.S > 1.0 ? 1.0 : hsl.S < 0.0 ? 0 : hsl.S;
			this.Luminosity = hsl.L > 1.0 ? 1.0 : hsl.L < 0.0 ? 0 : hsl.L;
		}

		public void ResetColor()
		{
			this.Hue = 0;
			this.Saturation = 1.0;
			this.Luminosity = .5;
		}
		#endregion
	}
}
