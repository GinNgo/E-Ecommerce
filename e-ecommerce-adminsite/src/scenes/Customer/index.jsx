import { Box, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";

// import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";
// import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";
import Header from "../../Components/Header";
import { useEffect, useState } from "react";
import UserApi from "../../Services/User/UserApi";
import { Grid } from "antd";

const Customer = () => {
  const theme = useTheme();

  const colors = tokens(theme.palette.mode);
  const columns = [
    {
      field: "userId",
      headerName: "UserId",
      flex: 1,

      cellClassName: "name-column--cell",
    },
    {
      field: "fullName",
      headerName: "FullName",
      flex: 1,

      cellClassName: "name-column--cell",
    },
    {
      field: "phone",
      headerName: "Phone",
      flex: 1,

      cellClassName: "name-column--cell",
    },
    {
      field: "email",
      headerName: "Email",
      flex: 1,

      cellClassName: "name-column--cell",
    },
    {
      field: "address",
      headerName: "Address",
      flex: 1,

      cellClassName: "name-column--cell",
    },
  ];
  const [responseData, setResponseData] = useState([]);
  const [pageSize, setPageSize] = useState(10);
  const [page, setPage] = useState(0);

  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const resp = await UserApi.GetCustomer();
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Box m="20px">
      <Box sx={{ display: "flex", alignItems: "center" }}>
        <Header title="CUSTOMER" subtitle="Managing the Customer" />{" "}
      </Box>
      <Box
        m="40px 0 0 0"
        height="75vh"
        sx={{
          "& .MuiDataGrid-root": {
            border: "none",
          },
          "& .MuiDataGrid-cell": {
            borderBottom: "none",
          },
          "& .name-column--cell": {
            color: colors.greenAccent[300],
          },
          "& .ckeck-colum--cell": {
            color: colors.greenAccent[600],
          },
          "& .no-ckeck-colum--cell": {
            color: colors.redAccent[500],
          },
          "& .create-colum--cell": {
            color: colors.blueAccent[700],
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            borderBottom: "none",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            borderTop: "none",
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiCheckbox-root": {
            color: `${colors.greenAccent[200]} !important`,
          },
          "& .MuiDataGrid-cell--textCenter": {
            justifyContent: "center",
          },
          "& .MuiDataGrid-columnHeaderTitle": {},
        }}
      >
        <DataGrid
          rows={responseData}
          style={{ fontSize: 14 }}
          columns={columns}
          loading={responseData.length === 0}
          getRowId={(row) => row.userId}
          page={page}
          pageSize={pageSize}
          onPageChange={(newPage) => setPage(newPage)}
          onPageSizeChange={(newPageSize) => setPageSize(newPageSize)}
          rowsPerPageOptions={[5, 10, 20]}
          pagination
          {...responseData}
        />
      </Box>
    </Box>
  );
};

export default Customer;
