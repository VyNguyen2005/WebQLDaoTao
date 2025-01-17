<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLMonHoc.aspx.cs" Inherits="WebQLDaoTao.QLMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ MÔN HỌC</h2>
    <hr />
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-8"> 
            <asp:GridView CssClass="table table-bordered" ID="gvMonHoc" runat="server" AutoGenerateColumns="False" DataKeyNames="MaMH" OnRowEditing="gvMonHoc_RowEditing" OnRowCancelingEdit="gvMonHoc_RowCancelingEdit" OnRowDeleting="gvMonHoc_RowDeleting" OnRowUpdating="gvMonHoc_RowUpdating">
                <Columns>
                    <asp:BoundField HeaderText="Mã môn học" DataField="MaMH" ReadOnly="true" />
                    <asp:BoundField HeaderText="Tên môn học" DataField="TenMH"/>
                    <asp:BoundField HeaderText="Số tiết" DataField="SoTiet"/>
                    <asp:CommandField HeaderText="Chọn tác vụ" ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button"
                        EditText="Sửa" DeleteText="Xóa"/>
                </Columns>
                <HeaderStyle BackColor="#0066cc" ForeColor="#ffffff"/>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
