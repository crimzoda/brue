   M S B A M L   `   `   `  ����?  ;Brue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BrueBrue  5   	       Brue.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Hardcodet.NotifyIcon.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar  5   	   localclr-namespace:Brue  5   	   -   5          � Title$
  Brue��5	   	   $	��450��6   $	��285��6#    � 
ResizeMode$ NoResize=�6F    � Icon$ ui/brue_bin.png��6\   .��5      � .+�5   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5          Name$ tbNotifyIcon��5      $y�Visible=�5         ToolTipText$
 Brue��5         
IconSource$ ui/favicon.ico��5         PopupActivation$ DoubleClick=�5       � ContextMenu 5      �� 5         ModernContextMenu#��[  6   .@�5      m� -   5         m�Name$ trayExit��5      $
��Exit��61   6?   5      5      �� 5   
   -   5        	 ��Name$	 tcNavigator��5   +   $��0, -23, 0, 0q�6   .@�5      �� $
��Main��6   .��5      � -   5        
 �Name$
 grdMain��5      $y�Visible=�6(    � RowDefinitions 5      �� 5      $
��184* �6(   �� 5      $	��30* �6(   .+�5       �� -   5         ��Name$ wpIdle��5    !   $��Center=�61   $��Center=�6L   .+�5!      �� $2��,Looks like you're in the clear...for now >:)��6$   ���	#FF2F48D46X   �� 5"      $��ui/brue_sleeping.png��6    $��64��6>   $��64��6I    �� BitmapScalingMode$ NearestNeighbor=�6U   $��10q�6�   5#      �� 5$      -   5        $ wpFiles��5$   !   $��10q�62   $��Stretch=�6>   $��0��6\   5&      �� 5'       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��RightToLeft=�6G   $��15, 0, 15, 0q�6c   .+�5(      �� -   5         ��Name$ 	btnFolder��5(   !   $��Recovery Folder��64     BrueButtonStyle#���  6N   $��Center=�6x   $��
0, 0, 5, 0q�6�   �� 5)      -	   5        $ btnSettings��5)   !   #���  66   $��Center=�6`   $��
0, 0, 5, 0q�6{   $��6q�6�   .��5*      �� $��ui/cogwheel.png��6$   $
��None=�6=   $ NearestNeighbor=�6L   5+      �� 5,      -
   5        $ btnAbout��5,   !   #���  63   $��Center=�6]   $��
0, 0, 5, 0q�6x   $��6q�6�   .��5-      �� $��ui/question_mark.png��6$   $
��None=�6B   $ NearestNeighbor=�6Q   5.      5/      50      51      �� 52      $��Settings��6   .��53      � -   5        $
 grdSettings��53      $y�Visible=�6,    54      �� 55      $
��184* �6(   �� 56      $	��30* �6(   .+�58      �� -   5        $ 
spSettings��58   !   $��Center=�65   $��0��6P   $��Stretch=�6]   $��20, 0, 20, 0q�6{   .+�59      �� $��Important File Types:��6    $��Center=�6@   ���	#FF2F48D46]   �� 5:      -   5         ��Name$ tbFlaggedFileTypes��5:   "   $��2q�6>   
���   �  BrueTextBox#��[ 6]   
 � Tag$ .docx, .pdf, .xslx��6�   �� 5;      -   5        $ btnSaveSettings��5;   !   $
��Save��6:   #���  6I   $��Center=�6s   $��Right=�6�   $��
0, 5, 0, 0q�6�   5<      �� 5=      $ 
Horizontal=�6!   $��1��6:   $��RightToLeft=�6G   $��15, 0, 15, 0q�6c   .+�5>      �� -   5        $ btnSettingsBacktoMain��5>   !   $
��Back��6@   #���  6O   $��Center=�6y   $��
0, 0, 5, 0q�6�   5?      5@      5A      �� 5B      $��About��6   .��5C      � -   5        $
 grdAbout��5C       5D      �� 5E      $
��184* �6(   �� 5F      $	��30* �6(   .+�5H      �� -   5        $ wpAbout��5H   !   $��Center=�62   $��0��6M   $��Center=�6Z   .+�5I      �� $��ui/brue_idle.png��6    $��64��6:   $��64��6E   $ NearestNeighbor=�6Q   $��10q�6�   �� 5J      ���	#FF2F48D4$
��Wrap=�6;    �� TextAlignment$ Center=�6O   $��10, 0, 10, 0q�6f   Welcome to Brue 1.0.0!�� 5K   $   �� 60   jhBrue's job is to keep track of any important files you may have in your recycle bin, and keep them safe.�� 5M      �� 6   For bugs and issues:�� 5N   "   �� 5O      -   5         ��Name$ 	hlContact��5O      $"��mailto:contactbrue@proton.me?�6+   .�6�   contactbrue@proton.me5Q      �� 5R      �� 6   !This app automatically updates.�� 5T      �� 6   �� 5U      -   5        $ hlDonate��5U      $C��=https://www.paypal.com/donate/?hosted_button_id=38LPX86KQRHC4?�6*   .�6�   Support Brue 💜5W      5X      5Y      �� 5Z      $ 
Horizontal=�6!   $��1��6:   $��RightToLeft=�6G   $��15, 0, 15, 0q�6c   .+�5[      �� -   5        $ btnBackToMain��5[   !   $
��Back��68   #���  6G   $��Center=�6q   $��
0, 0, 5, 0q�6�   5\      5^      5_      5`      5a      5b      