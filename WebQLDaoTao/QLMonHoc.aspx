<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLMonHoc.aspx.cs" Inherits="WebQLDaoTao.QLMonHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Contents/Paging.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ MÔN HỌC</h2>
    <hr />
    <div>
        <button type="button" class="btn btn-info btn-lg" style="margin-bottom: 5px;" data-toggle="modal" data-target="#modalOpenAddButton">Thêm mới</button>
        <!-- Modal -->
        <div class="modal fade" id="modalOpenAddButton" role="dialog">
            <div class="modal-dialog">

                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">THÊM MỚI MÔN HỌC</h4>
                    </div>
                    <div class="modal-body">
                        <div>
                            <div class="form-group">
                                <label>Mã môn</label>
                                <asp:TextBox ID="txtMamh" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="revMamh" runat="server" ErrorMessage="Mã môn học không được để trống" ControlToValidate="txtMamh" Text="(*)" Font-Size="Medium" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rvMamh" runat="server" ErrorMessage="Mã môn học phải là một số" ControlToValidate="txtMamh" Display="Dynamic" Text="(*)" ForeColor="Red" Font-Size="Medium" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Tên môn</label>
                                <asp:TextBox ID="txtTenmh" CssClass="form-control" runat="server" ControlToValidate="txtTenmh">
                                </asp:TextBox><asp:RequiredFieldValidator ID="revTenmh" runat="server" ErrorMessage="Tên môn học không được để trống" Text="(*)" ControlToValidate="txtTenmh" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Số tiết</label>
                                <asp:TextBox ID="txtsotiet" CssClass="form-control" runat="server" ControlToValidate="txtsotiet"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="revSotiet" runat="server" ErrorMessage="Số tiết không được để trống" Font-Size="Medium" Text="(*)" ControlToValidate="txtsotiet" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rvSotiet" runat="server" ErrorMessage="Số tiết phải là một số" ValidationExpression="^[1-9]\d*$" Font-Size="Medium" Text="(*)" ForeColor="Red" Display="Dynamic" ControlToValidate="txtsotiet"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnThem" class="btn btn-success" OnClick="btnThem_Click" runat="server" Text="Thêm" />
                            </div>
                        </div>
                    </div>
                    <asp:ValidationSummary ID="vsKq" runat="server" ForeColor="#FF3300" Font-Size="Medium" />
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:GridView CssClass="table table-bordered" ID="gvMonHoc" runat="server" AutoGenerateColumns="False" DataKeyNames="MaMH"
            OnRowEditing="gvMonHoc_RowEditing" OnRowCancelingEdit="gvMonHoc_RowCancelingEdit" OnRowDeleting="gvMonHoc_RowDeleting"
            OnRowUpdating="gvMonHoc_RowUpdating" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMonHoc_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Mã môn học" DataField="MaMH" ReadOnly="true" />
                <asp:BoundField HeaderText="Tên môn học" DataField="TenMH" />
                <asp:BoundField HeaderText="Số tiết" DataField="SoTiet" />
                <asp:TemplateField HeaderText="Chọn tác vụ">
                    <ItemTemplate>
                        <asp:Button ID="btnSua" runat="server" Text="Sửa" CommandName="Edit" CssClass="btn btn-primary"/>
                        <asp:LinkButton ID="btnXoa" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa môn học này ra khỏi danh sách?');"
                        runat="server" CommandName="Delete" CssClass="btn btn-danger">
                            <i class="fa-solid fa-trash" style="color: #fff; margin-right: 5px;"></i>Xóa
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-success" CommandName="Update"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-warning" CommandName="Cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#0066cc" ForeColor="#ffffff" />
            <PagerStyle HorizontalAlign="Center" CssClass="pager-style" />
        </asp:GridView>
    </div>
</asp:Content>
