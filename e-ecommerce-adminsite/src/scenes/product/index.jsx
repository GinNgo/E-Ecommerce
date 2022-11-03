import { Box, Grid, IconButton, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import CheckOutlinedIcon from "@mui/icons-material/CheckOutlined";
import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";
import CreateOutlinedIcon from "@mui/icons-material/CreateOutlined";
import Header from "../../Components/Header";
import { useEffect, useState } from "react";
import ProductApi from "../../Services/Product/ProductApi";

const Product = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const columns = [
    { field: "productId", headerName: "ID", flex: 0.5 },
    {
      field: "productName",
      headerName: "ProductName",
      flex: 3,
      cellClassName: "name-column--cell",
    },
    {
      field: "originName",
      headerName: "OriginName",
      flex: 1,
    },

    {
      field: "brandName",
      headerName: "BrandName",
      flex: 1,
    },

    {
      field: "Status",
      headerName: "Status",

      renderCell: ({ row: { status } }) => {
        return status === true ? (
          <CheckOutlinedIcon className="ckeck-colum--cell" />
        ) : (
          <CloseOutlinedIcon className="no-ckeck-colum--cell" />
        );
      },
    },

    {
      field: "isDeleted",
      headerName: "IsDeleted",
      cellClassName: "MuiDataGrid-cell--textCenter",

      renderCell: ({ row: { isDeleted } }) => {
        return isDeleted === true ? (
          <CheckOutlinedIcon className="ckeck-colum--cell" />
        ) : (
          <CloseOutlinedIcon className="no-ckeck-colum--cell" />
        );
      },
    },
    {
      field: "action",
      headerName: "Action",
      flex: 1,

      renderCell: ({ row: { ID } }) => {
        return (
          <Grid>
            <IconButton>
              <CreateOutlinedIcon className="create-colum--cell" />
            </IconButton>
            <IconButton>
              <DeleteOutlinedIcon className="no-ckeck-colum--cell" />
            </IconButton>
          </Grid>
        );
      },
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
      const resp = await ProductApi.GetProduct();
      console.log(resp.data);
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Box m="20px">
      <Header title="Product" subtitle="Managing the Product" />
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
        }}
      >
        <DataGrid
          checkboxSelection
          rows={responseData}
          columns={columns}
          loading={responseData.length === 0}
          getRowId={(row) => row.productId}
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

export default Product;
