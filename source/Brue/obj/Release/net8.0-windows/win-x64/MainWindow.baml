   M S B A M L   `   `   `  ���� ?  ;Brue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BrueBrue      Brue.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [Hardcodet.NotifyIcon.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar  localclr-namespace:Brue  -     � Title$
  Brue��$	��450��$	��285�� � 
ResizeMode$ NoResize=�.��� .+�3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -     Name$ tbNotifyIcon��$y�Visible=�   ToolTipText$
 Brue��   
IconSource$ ui/tray.ico��   PopupActivation$ DoubleClick=� � ContextMenu ��    ModernContextMenu#��[  .@�m� -    m�Name$ trayExit��$
��Exit���� -    ��Name$ tcNavigator��$��0, -23, 0, 0q�.@��� $
��Main��.��� -   	 �Name$	 grdMain��$y�Visible=�
 � RowDefinitions
 �� $
��184* ��� $	��30* �.+��� -    ��Name$ wpIdle��$��Center=�$��Center=�.+��� $2��,Looks like you're in the clear...for now >:)�����	#FF2F48D4�� $��ui/brue_sleeping.png��$��64��$��64�� �� BitmapScalingMode$ NearestNeighbor=�$��10q��� -   $ wpFiles��$��10q�$��Stretch=�$��0����  �� Orientation$ 
Horizontal=�$��1��$��RightToLeft=�$��15, 0, 15, 0q�.+��� -    ��Name$ 	btnFolder��$��Recovery Folder��  BrueButtonStyle#���  $��Center=�$��
0, 0, 5, 0q��� -	   $ btnSettings��#���  $��Center=�$��
0, 0, 5, 0q�$��6q�.���� $��ui/cogwheel.png��$
��None=�$ NearestNeighbor=��� -
   $ btnAbout��#���  $��Center=�$��
0, 0, 5, 0q�$��6q�.���� $��ui/question_mark.png��$
��None=�$ NearestNeighbor=��� $��Settings��.��� -   $	 grdSettings��$y�Visible=�
 �� $
��184* ��� $	��30* �.+��� -   $ 
spSettings��$��Center=�$��0��$��Stretch=�$��20, 0, 20, 0q�.+��� $��Important File Types:��$��Center=����	#FF2F48D4�� -    ��Name$ tbFlaggedFileTypes��$��2q�
���   �  BrueTextBox#��[ 
 � Tag$ .docx, .pdf, .xslx���� -   $ btnSaveSettings��$
��Save��#���  $��Center=�$��Right=�$��
0, 5, 0, 0q��� $ 
Horizontal=�$��1��$��RightToLeft=�$��15, 0, 15, 0q�.+��� -   $ btnSettingsBacktoMain��$
��Back��#���  $��Center=�$��
0, 0, 5, 0q��� $��About��.��� -   $	 grdAbout��
 �� $
��184* ��� $	��30* �.+��� -   $ wpAbout��$��Center=�$��0��$��Center=�.+��� $��ui/brue_idle.png��$��64��$��64��$ NearestNeighbor=�$��10q��� ���	#FF2F48D4$
��Wrap=� �� TextAlignment$ Center=�$��10, 0, 10, 0q�Welcome to Brue 1.0.0!�� �� jhBrue's job is to keep track of any important files you may have in your recycle bin, and keep them safe.�� �� For bugs and issues:�� �� -    ��Name$ 	hlContact��$"��mailto:contactbrue@proton.me?�.�contactbrue@proton.me�� �� !This app automatically updates.�� �� �� -   $ hlDonate��$C��=https://www.paypal.com/donate/?hosted_button_id=38LPX86KQRHC4?�.�Support Brue 💜�� $ 
Horizontal=�$��1��$��RightToLeft=�$��15, 0, 15, 0q�.+��� -   $ btnBackToMain��$
��Back��#���  $��Center=�$��
0, 0, 5, 0q�