   M S B A M L   `   `   `  ����A  =PM_QLK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PM_QLKPM_QLK  5   	   +clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	       PM_QLK.Views.OutputWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PM_QLK     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +
controlbarclr-namespace:PM_QLK.Views  5   	   -   5        $��window��5   	     � Title$  Quản lí xuất kho��5	   	   $	��800��6"   $
��1300��6/      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     outputVM � DataContext# �  5   	   .��5      �  � RowDefinitions 5   
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
Horizontal=�6-   $��5,5,5,25q�6F   .+�52      �� $��Center=�6"   $��5q�53   "   $	��128��54   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đơn xuất��56   "    % !MaterialDesignFloatingHintTextBox#��[ 57   "   ��55   "   �� *DisplayNameOutput+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57   "   (  "System.Windows.Controls.DatePicker  59      $
��auto��6%   $	��5,0q�62   $��Bottom=�6?   $ Ngày xuất��5;   %   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5=   %      Text 5:   %   �� *
DateOutput+$ TwoWay=�$ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��5=   %   5?      � 5A      $��1��6    � ColumnDefinitions 5B      �� 5C      61   �� 5D      61   �� 5E      61   .+�5H      �� $��Thêm��6!   $��5q�60   $��0��5J   !   
����p�� , (MaterialDesignRaisedSecondaryLightButton#��[ 5M   !    � ToolTip$ Add Data��5N   !   ��5I   !   �� *AddCommandOutput+{�5L   !   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5N   !   �� 5P      $��Sửa��6!   $��5q�6/   $��1��5R   !   
����p��#��[ 5U   !   $ Modify Data��5V   !   ��5Q   !   �� *EditCommandOutput+{�5T   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5V   !   �� 5X      $
��Xóa��6!   $��5q�6/   $��2��5Z   !   
����p��#��[ 5]   !   $ Delete Data��5^   !   ��5Y   !   �� *DeleteCommandOutput+{�5\   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5^   !   5_      �� 5a      $��2��6    $��5q�6-   6:     5c      $��3��6*   $��5q�5d      $��Stretch=�5e      .��5g      �� $
��Auto=�6'   $
��Auto=�5h        MaterialDesignScrollViewer#��[ 5i      .��5j      �� ��6'   �� *
ListOutput+ �� SelectedItem 6J   �� *SelectedItemSource+$ TwoWay=�$ PropertyChanged=�$ 
dd/MM/yyyy�� �� View 5k   "   �� 5l   &   .P�5m   *   �� $��Đơn xuất��69    �� DisplayMemberBinding 6K   �� *DisplayName+6z   �� 5n   *   $��Ngày xuất��69    6L   �� *
DateOutput+$ TwoWay=�$ PropertyChanged=�$ 
dd/MM/yyyy��6�   5o   '   5q      5r      5s      5t      5u        5w      $��1��6"   $��5q�6/   .��5x      �  5y      �� 5z      $
��auto �6(   68   �� 5{      $
��auto �6(   68   �� 5|      $
��auto �6(   68   �� 5}      6*   .+�5�      � $��0��6    $
 
Horizontal=�6-   $��5q�6F   .+�5�      �� $	��128��6#   $��5,0,5,0q�62    �� DisplayMemberPath$ DisplayName��5�      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ SecondaryLight=�5�      $ Khách hàng��5�       .   SecondaryHueMidBrush   UnderlineBrush# �  5�       &	 "MaterialDesignFloatingHintComboBox#��[	 5�      $��35��6[   ��5�      �� *ListCustomer+ 6D   �� *SelectedCustomer+$ TwoWay=�$ PropertyChanged=�5�   [   �� 5�      $	��128��6#   $��5,0,5,0q�62   $ DisplayName��5�      $ SecondaryLight=�5�      $ Tên vật tư��5�       . # �  5�      #��[	 5�      $��35��6[   ��5�      �� *
ListObject+ 6B   �� *SelectedObject+$ TwoWay=�$ PropertyChanged=�5�   [   �� 5�      $��Center=�6"   $��5q�5�      $	��128��5�      $ Số lượng��5�      #��[ 5�      ��5�      �� *Count+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��128��5�      $ Giá xuất��5�      #��[ 5�      ��5�      �� *OutputPrice+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��200��5�      $ Trạng thái xuất��5�      #��[ 5�      ��5�      �� *Status+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Center=�6"   $��5q�5�      $	��200��5�      $ Thành tiền��5�      #��[ 5�      ��5�      �� *Total+$ TwoWay=�$ PropertyChanged=�5�      5�      � 5�      $��1��6    5�      �� 5�      61   �� 5�      61   �� 5�      61   .+�5�      �� $��Thêm��6!   $��5q�60   $��0��5�   !   
����p��#��[ 5�   !   $ Add Data��5�   !   ��5�   !   �� *AddCommandOutputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   !   �� 5�      $��Sửa��6!   $��5q�6/   $��1��5�   !   
����p��#��[ 5�   !   $ Modify Data��5�   !   ��5�   !   �� *EditCommandOutputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   !   �� 5�      $
��Xóa��6!   $��5q�6/   $��2��5�   !   
����p��#��[ 5�   !   $ Delete Data��5�   !   ��5�   !   �� *DeleteCommandOutputInfo+{�5�   !   �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5�   !   5�      �� 5�      $��2��6    $��5q�6-   6:     5�      $��3��6*   $��5q�5�      $��Stretch=�5�      .��5�      �� $
��Auto=�6'   $
��Auto=�5�      #��[ 5�      .��5�      �� ��6'   �� *ListOutputInfo+ 6N   �� *SelectedItemSourceInfo+$ TwoWay=�$ PropertyChanged=� 5�   "   �� 5�   &   .P�5�   *   �� $��Đơn xuất��69    6K   �� *Output.DisplayName+6�   �� 5�   *   $��Khách hàng��69    6M   �� *Customer.DisplayName+6�   �� 5�   *   $��Tên vật tư��69    6M   �� *Object.DisplayName+6�   �� 5�   *   $��Số lượng��69    6K   �� *Count+6t   �� 5�   *   $��
Đơn vị��69    6I   �� *Unit.DisplayName+6}   �� 5�   *   $��Giá xuất��69    6K   �� *OutputPrice+6z   �� 5�   *   $��Trạng thái xuất��69    6R   �� *Status+6|   �� 5�   *   $��Thành tiền��69    6M   �� *Total+6v   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      