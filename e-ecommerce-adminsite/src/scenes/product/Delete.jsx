import { Box, Grid, Button, IconButton, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import CheckOutlinedIcon from "@mui/icons-material/CheckOutlined";
import AddCircleOutlineOutlinedIcon from "@mui/icons-material/AddCircleOutlineOutlined";
import CreateOutlinedIcon from "@mui/icons-material/CreateOutlined";
import Header from "../../Components/Header";
import { useEffect, useState } from "react";
import ProductApi from "../../Services/Product/ProductApi";
import { Link } from "react-router-dom";
import DeleteOutlinedIcon from "@mui/icons-material/DeleteOutline";

const DeleteProduct = () => {
  const url = "https://localhost:44324/wwwroot/upload/";
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const columns = [
    { field: "productId", headerName: "ID", flex: 0.5 },
    {
      field: "image",
      headerName: "Image",

      renderCell: ({ row: { images } }) => {
        return (
          <Grid>
            <img
              width="60px"
              src={url + images[0].imageUrl}
              alt={images[0].imageName}
            />
          </Grid>
        );
      },
    },
    {
      field: "productName",
      headerName: "ProductName",
      flex: 2,
      cellClassName: "name-column--cell",
    },

    {
      field: "price",
      headerName: "Price",
    },
    {
      field: "priceDiscount",
      headerName: "PriceDiscount",
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

      renderCell: ({ row: { productId } }) => {
        return (
          <Grid>
            <Link to={`/product/update/${productId}`}>
              <IconButton>
                <CreateOutlinedIcon className="create-colum--cell" />
              </IconButton>
            </Link>
          </Grid>
        );
      },
    },
  ];
  const checkSelection = () => {
    ProductApi.PutTrash(selectedRows);
    window.location.reload();
  };
  const deleteSelection = async () => {
    var result = await ProductApi.Delete(selectedRows);
    console.log(result);
    window.location.reload();
  };
  const [responseData, setResponseData] = useState([]);
  const [pageSize, setPageSize] = useState(10);
  const [page, setPage] = useState(0);
  const [selectedRows, setSelectedRows] = useState([]);
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const resp = await ProductApi.GetProductsTrash();

      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Box m="20px">
      <Box sx={{ display: "flex", alignItems: "center" }}>
        <Box sx={{ mr: 2 }}>
          <Header title="Product" subtitle="Managing the Product" />
        </Box>
        <Box sx={{ mr: 2 }}>
          <Link to={`/product`} style={{ listStyleType: "none" }}>
            <Button color="secondary" variant="contained">
              <DeleteOutlinedIcon />
              BACK TO PRODUCT
            </Button>
          </Link>
        </Box>
        <Box sx={{ mr: 2 }}>
          <Link to={`/product/create`} style={{ listStyleType: "none" }}>
            <Button color="secondary" variant="contained">
              <AddCircleOutlineOutlinedIcon />
              CREATE PRODUCT
            </Button>
          </Link>
        </Box>
        <Box sx={{ mr: 2 }}>
          <Button
            color="secondary"
            variant="contained"
            onClick={checkSelection}
          >
            <DeleteOutlinedIcon />
            RESTORE PRODUCT
          </Button>
        </Box>
        <Button color="secondary" variant="contained" onClick={deleteSelection}>
          <DeleteOutlinedIcon />
          DELETE PRODUCT
        </Button>
      </Box>
      <Box
        m="40px 0 0 0"
        height="75vh"
        sx={{
          "& .MuiDataGrid-root": {
            border: "none",
          },
          "& .MuiDataGrid-row": {
            alignItems: "center",
            minHeight: "68px !important",
            maxHeight: "68px !important",
          },
          "& .MuiDataGrid-cell": {
            minHeight: "68px !important",
            maxHeight: "68px !important",
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
          onSelectionModelChange={(ids) => {
            const selectedIDs = ids;
            console.log(selectedIDs);
            setSelectedRows(selectedIDs);
          }}
          {...responseData}
        />
      </Box>
    </Box>
  );
};

export default DeleteProduct;
