   M S B A M L   `   `   `  ����A  =PM_QLK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	   +clr-namespace:PM_QLK.ViewsPM_QLK.Views  5   	       PM_QLK.Views.UnitWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PM_QLK.Views     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +
controlbarclr-namespace:PM_QLK.Views  5   	   -   5        $��window��5   	     � Title$!  Quản lí đơn vị tính��5	   	   $	��800��6%   $
��1300��62      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 unitVM � DataContext# �  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5    
      PM_QLK.Views.ControlBar  $��0��6    
 � Tag 6-   �� *Title+	 �� ElementName$	 window��6Y   � 5"   
   $��1��6    5#      �� 5$      $
��auto �6    60   �� 5%      $
��auto �6    60   �� 5&      6"   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�5*   "   .��5+      �� $��Center=�6   $��5q�5,      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Tên đơn vị đo��5.       % !MaterialDesignFloatingHintTextBox#��[ 5/      ��5-      �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5/      50        52      $��1��6"   $��5q�53   "   .��54      �  � ColumnDefinitions 55      �� 56      6-   �� 57      6-   �� 58      6-   .+�5;      �� $��Thêm��6   $��5q�6,   $��0��5=      
����p�� , (MaterialDesignRaisedSecondaryLightButton#��[ 5@       � ToolTip$ Add Data��5A      ��5<      �� *
AddCommand+{�5?      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5A      �� 5C      $��Sửa��6   $��5q�6+   $��1��5E      
����p��#��[ 5H      $ Modify Data��5I      ��5D      �� *EditCommand+{�5G      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5I      �� 5K      $
��Xóa��6   $��5q�6+   $��2��5M      
����p��#��[ 5P      $ Delete Data��5Q      ��5L      �� *DeleteCommand+{�5O      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5Q      5R      5S        5U      $��2��6"   $��5q�5V   &   $��Stretch=�5W   &   .��5X      �� $
��Auto=�6   $
��Auto=�5Y        MaterialDesignScrollViewer#��[ 5Z      .��5[      �� ��6   �� *
ListUnit+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6r   �� *SelectedItemSource+$ TwoWay=�$ PropertyChanged=� �� View 5\      �� 5]      .P�5^   "   �� $	��STT��61    �� DisplayMemberBinding 6>   �� *STT+6e   �� 5_   "   $��Tên Đơn Vị��61    6E   �� *DisplayName+6t   5`      5b      5c      5d      5e      5f      5g      