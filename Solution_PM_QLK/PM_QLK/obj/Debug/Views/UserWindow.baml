   M S B A M L   `   `   `  ����A  =PM_QLK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	   +clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	       PM_QLK.Views.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PM_QLK.Views     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +
controlbarclr-namespace:PM_QLK.Views  5   	   -   5        $��window��5   	     � Title$  Quản lí tài khoản��5	   	   $	��800��6#   $
��1300��60      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 userVM � DataContext# �  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5    
      PM_QLK.Views.ControlBar  $��0��6    
 � Tag 6-   �� *Title+	 �� ElementName$	 window��6Y   � 5"   
   $��1��6    5#      �� 5$      $
��auto �6    60   �� 5%      $
��auto �6    60   �� 5&      6"   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�5*   "   .��5+      � 
 � Orientation$
 
Horizontal=�6   .+�5,      �� $��Center=�6   $��5q�5-      $	��128��5.      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��50       % !MaterialDesignFloatingHintTextBox#��[ 51      ��5/      �� *
UserName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�51      �� 53      $	��128��6   $��5,0,5,0q�6.   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ SecondaryLight=�55      $ Quyền truy cập��56      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .   SecondaryHueMidBrush   UnderlineBrush# �  58       & "MaterialDesignFloatingHintComboBox#��[ 59      $��35��6[   ��54      �� *Role+ �� SelectedItem 6<   �� *SelectedRole+$ TwoWay=�$ PropertyChanged=�59   [   �� 5;      $��Center=�6   $��5q�5<      $	��128��5=      $ Tên hiển thị��5?      #��[ 5@      ��5>      �� *DisplayName+$ TwoWay=�$ PropertyChanged=�5@      5B      5D        5F      $��1��6"   $��5q�5G   "   .��5H      �  � ColumnDefinitions 5I      �� 5J      6-   �� 5K      6-   �� 5L      6-   �� 5M      6-   .+�5P      �� $��Thêm��6   $��5q�6,   $��0��5R      
����p�� , (MaterialDesignRaisedSecondaryLightButton#��[ 5U       � ToolTip$ Add Data��5V      ��5Q      �� *
AddCommand+{�5T      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5V      �� 5X      $��Sửa��6   $��5q�6+   $��1��5Z      
����p��#��[ 5]      $ Modify Data��5^      ��5Y      �� *EditCommand+{�5\      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5^      �� 5`      $
��Xóa��6   $��5q�6+   $��2��5b      
����p��#��[ 5e      $ Delete Data��5f      ��5a      �� *DeleteCommand+{�5d      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5f      �� 5h      $��Đổi Password��6   $��5q�64   $��3��5j      
����p��#��[ 5m      $ Change Password of User��5n      ��5i      �� *ChangePasswordCommand+{�5l      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5n      5o      5p        5r      $��2��6"   $��5q�5s   &   $��Stretch=�5t   &   .��5u      �� $
��Auto=�6   $
��Auto=�5v        MaterialDesignScrollViewer#��[ 5w      .��5x      �� ��6   �� *
ListUser+ 6@   �� *SelectedItemSource+$ TwoWay=�$ PropertyChanged=� �� View 5y      �� 5z      .P�5{   "   �� $	��STT��61    �� DisplayMemberBinding 6>   �� *STT+6e   �� 5|   "   $��Tên đăng nhập��61    6H   �� *
UserName+6t   �� 5}   "   $��Chức vụ��61    6B   �� *Role+6j   �� 5~   "   $��Tên hiển thị��61    6G   �� *DisplayName+6v   5      5�      5�      5�      5�      5�      5�      