   M S B A M L   `   `   `  ���� ?  ;Brue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BrueBrue      Brue.App   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     $localclr-namespace:Brue       �� 	Resources     ButtonColor �� Color  ButtonTextColor  ButtonHoverColor  ButtonPressColor  TextBoxActiveColor  BrueButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels	 �� Padding
 ��Name �� Triggers P� Property P� Value �� 
TargetName  BrueTextBox ��Name J� IsHitTestVisible �� RelativeSource �� AncestorType �� Triggers �� Binding �� Value ��Name  ModernMenuItem  ModernContextMenu3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   Opacity   ShadowDepth   Color J� Effect K� IsItemsHost �� 	Resources �� BasedOn��%)	  &	        &	      &	 $     &	 7     &	 J     &	 Z     &	 h    &	 m    &	 �    7  �� $ #304FFE���� $ #FFFF���� $ #0026CA���� $ #7A7CFF���� $
 Gray���� " ��.���  � ��# �   ��  � ��# �  ��  � ��$ 12, 6, 12, 6q���  � ��$ 0q���  � ��$ 40����  � ��$
 Auto����  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R��� $ 	btnBorder��$ 3��#��z��#��z��#��z��#��z��$
 True��#	 z��._��� $
 ContentPresenter��$|�False��#��z��#��z��# z $
��True�� P�  �@J�IsMouseOver$
 True��. ��� $ 	btnBorder��# �   � ��P�  � ��$
 True��. ��� $ 	btnBorder��# �   � ���� " ��.���  � ��
 �������  � ��$ 1q���  � ��$ 2q���  � ��
 �������  � ��$ 20����  � ��$ 20����  � �� �� " ��.R�� .+��� $ Placeholder��$��4,2,0,0q�
�������$ False��$y�Visible=����� *Tag+ �� " ������ " ��.���  � y�$ 	Collapsed=� ��  �� *Text+ ��  TextBox  .a���  � y�$ Visible=��� $ tbBorder��$
 True��
������ #��z��#��z��$ 2��._��� $ PART_ContentHost��
������ $��Hidden=�$��Hidden=� P�  �@J�IsKeyboardFocused$
 True��. ��� $ tbBorder��# �   � ��P�  Z�  � ��. ��� $ Placeholder�� � y�$ Visible=�P�  � ��$  ��. ��� $ Placeholder�� � y�$ Visible=��� " m�.���  � ��$ 28����  � ��$
 12,0q���  � ��$ 12(���  � ��
 ���� ��  � �� �#2c2c2c��  � �� �� " m�.R��� $ Border��#��z��$��0q�._�� .+��� #��z��#��z��$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ Border�� � �� �#f0f0f0P�  �@m�	IsPressed$
 True��. ��� $ Border�� � �� �#e5e5e5�� " ��.���  � ��
 �������  � �� �#dadce0��  � ��$ 1q���  � ��$ 0q���  �@J�Effect   $ 8Q�$	 270Q�$	 0.2Q�$ 2Q�$ #000000����  � �� �� " ��.R��� #��z��#��z��#��z��#	 z��# z $ 4��._��� $
 True�� ���� 'm�       " m�8   �� '��       " ��.���  � ��$ 1����  � ��$	 0,4q���  � �� �� " ��.R��� $��0q����#e8eaed$��1��$
 True��