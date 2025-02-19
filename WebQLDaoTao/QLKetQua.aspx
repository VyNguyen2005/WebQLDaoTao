<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLKetQua.aspx.cs" Inherits="WebQLDaoTao.KetQua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h5 class="alert alert-success">QUẢN LÝ ĐIỂM</h5>
    <hr />
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-2">Chọn môn học</label>
            <div class="col-md-2" style="padding: 0 10px;">
                <asp:DropDownList ID="ddlMonHoc" AutoPostBack="True" runat="server" CssClass="form-control" DataSourceID="ods_MonHoc" DataTextField="TenMH" DataValueField="MaMH"></asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="gvKetQua" ShowFooter="True" runat="server" DataSourceID="ods_KetQua"
        AutoGenerateColumns="False" CssClass="table table-bordered" Width="50%" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" SortExpression="MaSV" />
            <asp:BoundField DataField="HoTenSV" HeaderText="Họ tên sinh viên" SortExpression="HoTenSV" />
            <asp:TemplateField HeaderText="Điểm thi">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiem" runat="server" CssClass="form-control" Text='<%# Eval("Diem") %>'></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnLuu" CssClass="btn btn-success" runat="server" Text="Lưu điểm" OnClick="btnLuu_Click"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chọn">
                <ItemTemplate>
                    <asp:CheckBox ID="chkChon" runat="server" CssClass="radio-inline" AutoPostBack="true"/>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnXoa_Click"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   
    <asp:ObjectDataSource ID="ods_MonHoc" runat="server" SelectMethod="getAll" TypeName="WebQLDaoTao.Models.MonHocDAO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ods_KetQua" runat="server" SelectMethod="findByMaMH" TypeName="WebQLDaoTao.Models.KetQuaDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMonHoc" Name="mamh" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
