   M S B A M L   `   `   `  ����A  =PM_QLK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PM_QLKPM_QLK  5   	   +clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	       PM_QLK.Views.InputWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PM_QLK     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +
controlbarclr-namespace:PM_QLK.Views  5   	   -   5        $��window��5   	     � Title$  Quản lí nhập kho��5	   	   $	��800��6"   $
��1300��6/      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     inputVM � DataContext# �  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5    
      PM_QLK.Views.ControlBar  $��0��6    
 � Tag 6-   �� *Title+	 �� ElementName$	 window��6Y   � 5"   
   $��1��6    5#      �� 5$      $
��auto �6    60   �� 5%      6"   .+�5(      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5)      �  5*      �� 5+      $
��auto �6(   68   �� 5,      $
��auto �6(   68   �� 5-      $
��auto �6(   68   �� 5.      $	��250 �6(   67   .+�51      � $��0��6    
 � Orientation$
 
Horizontal=�6-   $��5,5,5,25q�6F   .+�52      �� $��Center=�6"   $��5q�53      $	��128��54      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đơn nhập��56       % !MaterialDesignFloatingHintTextBox#��[ 57      ��55      �� *DisplayNameInput+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57      (  "System.Windows.Controls.DatePicker  59      $��5q�6%   $	��128��60   $��Bottom=�6?   $ Ngày nhập��5;   !   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5=   !      Text 5:   !   �� *	DateInput+$ TwoWay=�$ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��5=   !   5?      � 5A      $��1��6    � ColumnDefinitions 5B      �� 5C      $	��61* �6/   6=   �� 5D      $
��369* �6/   �� 5E      $
��430* �6/   6>   �� 5F      $
��430* �6/   6>   .+�5I      �� $��Thêm��6!   $��5,5,5,5q�60   
����p��$��0��5L   !    , (MaterialDesignRaisedSecondaryLightButton#��[ 5N   !    � ToolTip$ Add Data��5O   !   $��2��64   ��5J   !   �� *AddCommandInput+{�5M   !   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5O   4   �� 5P      $��Sửa��6!   $��5,5,5,5q�6/   
����p��$��2��5S   !   #��[ 5U   !   $ Modify Data��5V   !   ��5Q   !   �� *EditCommandInput+{�5T   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5V   !   �� 5W      $
��Xóa��6!   $��5,5,5,5q�6/   $��3��5Y   !   
����p��#��[ 5\   !   $ Delete Data��5]   !   ��5X   !   �� *DeleteCommandInput+{�5[   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5]   !   5^      �� 5`      $��2��6    $��5q�6-   6:     5b      $��3��6*   $��5q�5c      $��Stretch=�5d      .��5f      �� $
��Auto=�6'   $
��Auto=�5g        MaterialDesignScrollViewer#��[ 5h      .��5i      �� ��6'   �� *	ListInput+ �� SelectedItem 6I   �� *SelectedItemSource+$ TwoWay=�$ PropertyChanged=� �� View 5j   "   �� 5k   &   .P�5l   *   �� $��Đơn nhập��69    �� DisplayMemberBinding 6K   �� *DisplayName+6z   �� 5m   *   $��Ngày nhập��69    6L   �� *	DateInput+$ 
dd/MM/yyyy��6�   5n   '   5p      5q      5r      5s      5t        5v      $��1��6"   $��5q�6/   .��5w      �  5x      �� 5y      $
��auto �6(   68   �� 5z      $
��auto �6(   68   �� 5{      $
��auto �6(   68   �� 5|      6*   .+�5      � $��0��6    $
 
Horizontal=�6-   $��5q�6F   .+�5�      �� $	��128��6#   $��5,0,5,0q�62    �� DisplayMemberPath$ DisplayName��5�      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ SecondaryLight=�5�      $ Tên vật tư��5�       .   SecondaryHueMidBrush   UnderlineBrush# �  5�       &	 "MaterialDesignFloatingHintComboBox#��[	 5�      $��35��6[   ��5�      �� *
ListObject+ 6B   �� *SelectedObject+$ TwoWay=�$ PropertyChanged=�5�   [   �� 5�      $��Center=�6"   $��5q�5�      $	��128��5�      $ Số lượng��5�      #��[ 5�      ��5�      �� *Count+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��128��5�      $ Giá nhập��5�      #��[ 5�      ��5�      �� *
InputPrice+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��200��5�      $ Trạng thái nhập��5�      #��[ 5�      ��5�      �� *Status+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��200��5�      $ Thành tiền��5�      #��[ 5�      ��5�      �� *Total+$ TwoWay=�$ PropertyChanged=�5�      5�      � 5�      $��1��6    5�      �� 5�      $	��29* �6/   6=   �� 5�      $	��21* �6/   �� 5�      $	��39* �6/   �� 5�      $
��341* �6/   �� 5�      $
��430* �6/   6>   �� 5�      $
��430* �6/   6>   .+�5�      �� $��Thêm��6!   $��5,5,5,5q�60   $��0��5�   !   
����p��#��[ 5�   !   $ Add Data��5�   !   $��4��64   ��5�   !   �� *AddCommandInputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   4   �� 5�      $��Sửa��6!   $��5,5,5,5q�6/   $��4��5�   !   
����p��#��[ 5�   !   $ Modify Data��5�   !   ��5�   !   �� *EditCommandInputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   !   �� 5�      $
��Xóa��6!   $��5,5,5,5q�6/   $��5��5�   !   
����p��#��[ 5�   !   $ Delete Data��5�   !   ��5�   !   �� *DeleteCommandInputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   !   5�      �� 5�      $��2��6    $��5q�6-   6:     5�      $��3��6*   $��5q�5�      $��Stretch=�5�      .��5�      �� $
��Auto=�6'   $
��Auto=�5�      #��[ 5�      .��5�      �� ��6'   �� *ListInputInfo+ 6M   �� *SelectedItemSourceInfo+$ TwoWay=�$ PropertyChanged=� 5�   "   �� 5�   &   .P�5�   *   �� $��Đơn nhập��69    6K   �� *Input.DisplayName+6�   �� 5�   *   $��Tên vật tư��69    6M   �� *Object.DisplayName+6�   �� 5�   *   $��Số lượng��69    6K   �� *Count+6t   �� 5�   *   $��
Đơn vị��69    6I   �� *Unit.DisplayName+6}   �� 5�   *   $��Nhà cung cấp��69    6O   �� *Suplier.DisplayName+6�   �� 5�   *   $��Giá nhập��69    6K   �� *
InputPrice+6y   �� 5�   *   $��Trạng thái nhập��69    6R   �� *Status+6|   �� 5�   *   $��Thành tiền��69    6M   �� *Total+6v   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      