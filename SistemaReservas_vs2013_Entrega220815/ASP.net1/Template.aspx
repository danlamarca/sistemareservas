<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="Template" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <asp:FormView ID="FormView2" runat="server" AllowPaging="True" CellPadding="4" 
            align = "left" DataKeyNames="ID_PRODUCT" DataSourceID="Conexao" ForeColor="#333333" 
            Width="407px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditItemTemplate>
                <font color = 'White'>ID PRODUCT:</font>
                <asp:Label ID="ID_PRODUCTLabel1" runat="server" 
                    Text='<%# Eval("ID_PRODUCT") %>' />
                <br />
               <font color='White'>Name Product:</font> 
                <asp:TextBox ID="Name_ProductTextBox" runat="server" 
                    Text='<%# Bind("Name_Product") %>' />
                <br />
                <font color = 'White'>Value Product:</font>
                <asp:TextBox ID="Value_ProductTextBox" runat="server" 
                    Text='<%# Bind("Value_Product") %>' style="margin-left: 2px" />
                <br /> <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" Forecolor="white"/>&nbsp;&nbsp;
                <asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" ForeColor="white" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Name Product:&nbsp;&nbsp;
                <asp:TextBox ID="Name_ProductTextBox" runat="server" 
                    Text='<%# Bind("Name_Product") %>' Height="20px" style="margin-left: 4px" 
                    Width="118px" />
                <br />
                Value Product:&nbsp;&nbsp;
                <asp:TextBox ID="Value_ProductTextBox" runat="server" 
                    Text='<%# Bind("Value_Product") %>' Height="20px" style="margin-left: 6px" 
                    Width="118px" />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" ForeColor="yellow" /> &nbsp;
                <asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" 
                    ForeColor="yellow"/>
            </InsertItemTemplate>
            <ItemTemplate>
                <font color ='green'>Id Product:</font>
                <asp:Label ID="ID_PRODUCTLabel" runat="server" 
                    Text='<%# Eval("ID_PRODUCT") %>' ForeColor="Red" />
                <br />
                <font color ='green'>Name Product:</font>
                <asp:Label ID="Name_ProductLabel" runat="server" 
                    Text='<%# Bind("Name_Product") %>' ForeColor="Red" />
                <br />
                <font color ='green'>Value Product:</font>
                <asp:Label ID="Value_ProductLabel" runat="server" 
                    Text='<%# Bind("Value_Product") %>' ForeColor="Red" />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" ForeColor="Red"/>
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" ForeColor="Red" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" ForeColor="Red" />
            </ItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <EditRowStyle BackColor="#2461BF" />
                      
        </asp:FormView>
        <asp:SqlDataSource ID="Conexao" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:Conexao %>"  
            DeleteCommand="DELETE FROM [PRODUCT] WHERE [ID_PRODUCT] = @original_ID_PRODUCT AND (([Name_Product] = @original_Name_Product) OR ([Name_Product] IS NULL AND @original_Name_Product IS NULL)) AND (([Value_Product] = @original_Value_Product) OR ([Value_Product] IS NULL AND @original_Value_Product IS NULL))" 
            InsertCommand="INSERT INTO [PRODUCT] ([Name_Product], [Value_Product]) VALUES (@Name_Product, @Value_Product)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT [ID_PRODUCT], [Name_Product], [Value_Product] FROM [PRODUCT]" 
            UpdateCommand="UPDATE [PRODUCT] SET [Name_Product] = @Name_Product, [Value_Product] = @Value_Product WHERE [ID_PRODUCT] = @original_ID_PRODUCT ">
            <DeleteParameters>
                <asp:Parameter Name="original_ID_PRODUCT" Type="Int32" />
                <asp:Parameter Name="original_Name_Product" Type="String" />
                <asp:Parameter Name="original_Value_Product" Type="Decimal" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name_Product" Type="String" />
                <asp:Parameter Name="Value_Product" Type="Double" />
                <asp:Parameter Name="original_ID_PRODUCT" Type="Int32" />
                <asp:Parameter Name="original_Name_Product" Type="String" />
                <asp:Parameter Name="original_Value_Product" Type="Decimal" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Name_Product" Type="String" />
                <asp:Parameter Name="Value_Product" Type="Double" />
            </InsertParameters>
        </asp:SqlDataSource>
      







</asp:Content>

