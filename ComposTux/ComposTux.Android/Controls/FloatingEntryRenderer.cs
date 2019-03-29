﻿using Android.Content;
using Android.Content.Res;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using ComposTux.Controls;
using ComposTux.Droid.Controls;
using Java.Lang;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AColor = Android.Graphics.Color;


[assembly: ExportRenderer(typeof(FloatingEntry), typeof(FloatingEntryRenderer))]
namespace ComposTux.Droid.Controls
{
    public class FloatingEntryRenderer : ViewRenderer<FloatingEntry, TextInputLayout>, ITextWatcher, TextView.IOnEditorActionListener
    {

        private bool _hasFocus;
        private ColorStateList _defaultTextColor;
        public FloatingEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected EditText EditText => Control.EditText;
        public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
        {
            if ((actionId == ImeAction.Done) || ((actionId == ImeAction.ImeNull) && (e.KeyCode == Keycode.Enter)))
            {
                Control.ClearFocus();
                HideKeyboard();
                ((IEntryController)Element).SendCompleted();
            }
            return true;
        }
        public virtual void AfterTextChanged(IEditable s)
        {
        }
        public virtual void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }
        public virtual void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (string.IsNullOrWhiteSpace(Element.Text) && (s.Length() == 0)) return;
            ((IElementController)Element).SetValueFromRenderer(Entry.TextProperty, s.ToString());
        }
        protected override TextInputLayout CreateNativeControl()
        {
            var textInputLayout = new TextInputLayout(Context);
            var editText = new AppCompatEditText(Context)
            {
                SupportBackgroundTintList = ColorStateList.ValueOf(GetPlaceholderColor())
            };
            editText.SetTextSize(ComplexUnitType.Sp, (float)Element.FontSize);
            textInputLayout.AddView(editText);
            return textInputLayout;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingEntry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                if (Control != null)
                    EditText.FocusChange -= ControlOnFocusChange;
            if (e.NewElement != null)
            {
                var ctrl = CreateNativeControl();
                SetNativeControl(ctrl);
                if (!string.IsNullOrWhiteSpace(Element.AutomationId))
                    EditText.ContentDescription = Element.AutomationId;
                _defaultTextColor = EditText.TextColors;
                Focusable = true;
                EditText.ShowSoftInputOnFocus = true;
                // Subscribe
                EditText.FocusChange += ControlOnFocusChange;
                EditText.AddTextChangedListener(this);
                EditText.SetOnEditorActionListener(this);
                EditText.ImeOptions = ImeAction.Done;
                SetText();
                SetHintText();
                SetInputType();
                SetTextColor();
                SetHorizontalTextAlignment();
                SetFloatingHintEnabled();
                SetIsEnabled();
                SetLabelAndUnderlineColor();
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
                SetHintText();
            else if (e.PropertyName == Entry.IsPasswordProperty.PropertyName ||
                     e.PropertyName == InputView.KeyboardProperty.PropertyName)
                SetInputType();
            else if (e.PropertyName == Entry.TextProperty.PropertyName)
                SetText();
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
                SetHorizontalTextAlignment();
            else if (e.PropertyName == FloatingEntry.FloatingHintEnabledProperty.PropertyName)
                SetFloatingHintEnabled();
            else if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
                SetIsEnabled();
            else if (e.PropertyName == FloatingEntry.ActivePlaceholderColorProperty.PropertyName ||
                     e.PropertyName == Entry.PlaceholderColorProperty.PropertyName)
                SetLabelAndUnderlineColor();
            else if (e.PropertyName == Entry.TextColorProperty.PropertyName)
                SetTextColor();
        }
        private void ControlOnFocusChange(object sender, FocusChangeEventArgs args)
        {
            _hasFocus = args.HasFocus;
            if (_hasFocus)
            {
                var manager = (InputMethodManager)Android.App.Application.Context.GetSystemService(Context.InputMethodService);
                EditText.PostDelayed(() =>
                {
                    EditText.RequestFocus();
                    manager.ShowSoftInput(EditText, 0);
                },
                    60);
            }
            var isFocusedPropertyKey = Element.GetInternalField<BindablePropertyKey>("IsFocusedPropertyKey");
            ((IElementController)Element).SetValueFromRenderer(isFocusedPropertyKey, _hasFocus);
            SetUnderlineColor(_hasFocus ? GetActivePlaceholderColor() : GetPlaceholderColor());
        }

        protected AColor GetPlaceholderColor() => Element.PlaceholderColor.ToAndroid(Color.FromHex("#80000000"));

        private AColor GetActivePlaceholderColor() => Element.ActivePlaceholderColor.ToAndroid(global::Android.Resource.Attribute.ColorAccent, Context);

        protected virtual void SetLabelAndUnderlineColor()
        {
            var defaultColor = GetPlaceholderColor();
            var activeColor = GetActivePlaceholderColor();
            SetHintLabelDefaultColor(defaultColor);
            SetHintLabelActiveColor(activeColor);
            SetUnderlineColor(_hasFocus ? activeColor : defaultColor);
        }
        private void SetUnderlineColor(AColor color)
        {
            var element = (ITintableBackgroundView)EditText;
            element.SupportBackgroundTintList = ColorStateList.ValueOf(color);
        }
        private void SetHintLabelActiveColor(AColor color)
        {
            var hintText = Control.Class.GetDeclaredField("mFocusedTextColor");
            hintText.Accessible = true;
            hintText.Set(Control, new ColorStateList(new int[][] { new[] { 0 } }, new int[] { color }));
        }
        private void SetHintLabelDefaultColor(AColor color)
        {
            var hint = Control.Class.GetDeclaredField("mDefaultTextColor");
            hint.Accessible = true;
            hint.Set(Control, new ColorStateList(new int[][] { new[] { 0 } }, new int[] { color }));
        }
        private void SetText()
        {
            if (EditText.Text != Element.Text)
            {
                EditText.Text = Element.Text;
                if (EditText.IsFocused)
                    EditText.SetSelection(EditText.Text.Length);
            }
        }
        private void SetHintText()
        {
            Control.Hint = Element.Placeholder;
        }
        private void SetTextColor()
        {
            if (Element.TextColor == Color.Default)
            {
                EditText.SetTextColor(_defaultTextColor);
            }
            else
            {
                EditText.SetTextColor(Element.TextColor.ToAndroid());
            }
        }
        private void SetHorizontalTextAlignment()
        {
            switch (Element.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    EditText.Gravity = GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    EditText.Gravity = GravityFlags.Right;
                    break;
                default:
                    EditText.Gravity = GravityFlags.Left;
                    break;
            }
        }
        public void SetFloatingHintEnabled()
        {
            Control.HintEnabled = Element.FloatingHintEnabled;
            Control.HintAnimationEnabled = Element.FloatingHintEnabled;
        }
        protected void HideKeyboard()
        {
            var manager = (InputMethodManager)Android.App.Application.Context.GetSystemService(Context.InputMethodService);
            manager.HideSoftInputFromWindow(EditText.WindowToken, 0);
        }
        private void SetIsEnabled()
        {
            EditText.Enabled = Element.IsEnabled;
        }
        private void SetInputType()
        {
            EditText.InputType = Element.Keyboard.ToInputType();
            if (Element.IsPassword && (EditText.InputType & InputTypes.ClassText) == InputTypes.ClassText)
            {
                EditText.TransformationMethod = new PasswordTransformationMethod();
                EditText.InputType = EditText.InputType | InputTypes.TextVariationPassword;
            }
            if (Element.IsPassword && (EditText.InputType & InputTypes.ClassNumber) == InputTypes.ClassNumber)
            {
                EditText.TransformationMethod = new PasswordTransformationMethod();
                EditText.InputType = EditText.InputType | InputTypes.NumberVariationPassword;
            }
        }
    }
}
