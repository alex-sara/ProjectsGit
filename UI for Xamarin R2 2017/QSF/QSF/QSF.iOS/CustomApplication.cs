using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using System.Linq;

namespace QSF.iOS
{
    public class QTouchposeFingerView : UIView
    {
        public CATransform3D TouchEndTransform { get; private set; }

        public UIImage CustomTouchImage { get; private set; }

        public CGPoint CustomTouchPoint { get; private set; }

        public double _touchEndAnimationDuration { get; set; }

        public QTouchposeFingerView(CGRect frame)
        {
            this.Frame = frame;
        }

        public QTouchposeFingerView(CGPoint point, UIColor color, UIImage image, double touchEndAnimationDuration, CATransform3D touchEndTransform)
        {
            if (image != null)
            {
                CGRect frame = new CGRect(point.X - CustomTouchPoint.X,
                                          point.Y - CustomTouchPoint.Y,
                                          image.Size.Width,
                                          image.Size.Height);

                this.Frame = frame;

                this.Opaque = false;

                UIImageView iv = new UIImageView(image);
                this.Add(iv);
            }
            else
            {
                nfloat kFingerRadius = 11.0f;

                var fr = new CGRect(point.X - kFingerRadius, point.Y - kFingerRadius, 2 * kFingerRadius, 2 * kFingerRadius);

                this.Frame = fr;
                {
                    this.Opaque = false;
                    this.Layer.BorderColor = color.ColorWithAlpha(0.6f).CGColor;
                    this.Layer.CornerRadius = kFingerRadius;
                    this.Layer.BorderWidth = 2.0f;
                    this.Layer.BackgroundColor = color.ColorWithAlpha(0.4f).CGColor;

                    _touchEndAnimationDuration = touchEndAnimationDuration;
                    TouchEndTransform = touchEndTransform;
                }
            }
        }

        public override void RemoveFromSuperview()
        {
            UIView.Animate(_touchEndAnimationDuration, () =>
             {
                 this.Alpha = 0;
                 this.Layer.Transform = this.TouchEndTransform;
             }, () =>
              {
                  base.RemoveFromSuperview();
              }
             );
        }
    }

    [Register("CustomApplication")]
    public class CustomApplication : UIApplication
    {
        UIView _touchView;
        private Dictionary<UITouch, UIView> touchDictionary = new Dictionary<UITouch, UIView>();
        private bool showTouches = false;
        private UIColor touchColor;
        private double touchEndAnimationDuration;
        private CATransform3D touchEndTransform;
        private UIImage customTouchImage;

        public CustomApplication()
        {
            touchColor = new UIColor(1f, 0, 0, 1f);
            touchEndAnimationDuration = 0.5f;
            touchEndTransform = CATransform3D.MakeScale(1.5f, 1.5f, 1);

            customTouchImage = null;
        }

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            base.ObserveValue(keyPath, ofObject, change, context);
            UpdateTouchView();
        }

        public void EnableTouchVisuals()
        {
            this.showTouches = true;
        }

        public void UpdateTouchView()
        {
            if (this.showTouches)
            {
                if (_touchView == null && this.KeyWindow != null)
                {
                    UIWindow window = this.KeyWindow;
                    _touchView = new QTouchposeFingerView(this.KeyWindow.Frame);
                    _touchView.BackgroundColor = UIColor.Clear;
                    _touchView.Opaque = false;
                    _touchView.UserInteractionEnabled = false;
                    window.AddSubview(_touchView);
                }
            }
            else
            {
                if (_touchView != null)
                {
                    _touchView.RemoveFromSuperview();
                    _touchView = null;
                }
            }
        }

        public override void SendEvent(UIEvent uievent)
        {
            if (showTouches && uievent.AllTouches != null)
            {
                this.UpdateTouch(uievent.AllTouches);
            }
            base.SendEvent(uievent);
        }

        private void UpdateTouch(NSSet touches)
        {
            UIView fingerView;

            if (_touchView == null)
            {
                UpdateTouchView();
            }

            foreach (UITouch touch in touches)
            {
                CGPoint point = touch.LocationInView(_touchView);
                touchDictionary.TryGetValue(touch, out fingerView);

                if (touch.Phase == UITouchPhase.Cancelled || touch.Phase == UITouchPhase.Ended)
                {
                    if (fingerView != null)
                    {
                        touchDictionary.Remove(touch);
                        fingerView.RemoveFromSuperview();
                    }
                }
                else
                {
                    if (fingerView == null)
                    {
                        fingerView = new QTouchposeFingerView(point, touchColor, customTouchImage, touchEndAnimationDuration, touchEndTransform);
                        _touchView.Add(fingerView);
                        touchDictionary[touch] = fingerView;
                    }
                    else
                    {
                        if (this.customTouchImage != null)
                        {
                            CGPoint newCenter = point;
                            newCenter.X += (this.customTouchImage.Size.Width / 2);
                            newCenter.Y += (this.customTouchImage.Size.Height / 2);

                            fingerView.Center = newCenter;
                        }
                        else
                        {
                            fingerView.Center = point;
                        }
                    }
                }
            }
        }

        private void RemoveActiveTouches(NSSet activeTouches)
        {
            foreach (var touch in this.touchDictionary.Keys.ToList())
            {
                if (activeTouches == null || !activeTouches.Contains(touch))
                {
                    var view = this.touchDictionary[touch];
                    this.touchDictionary.Remove(touch);
                }
            }
        }
    }
}
