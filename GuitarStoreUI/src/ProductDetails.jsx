import {
  Box,
  Button,
  ButtonGroup,
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  CircularProgress,
  Container,
  Grid,
  Stack,
  Typography,
  colors,
} from '@mui/material';
import { useState } from 'react';
import { Link, useParams } from 'react-router';
import { Breadcrumb } from './Breadcrumb';
import { ConfirmDialog } from './ConfirmDialog';
import { useFetch, useMakeOrderMutation } from './api';
import { priceFormatter } from './utils';

export function ProductDetails() {
  const params = useParams();
  const store = useFetch(`/store/${params.storeId}`);
  const { data, loading, error } = useFetch(`/product/${params.productId}`);

  const storeQuantity = useFetch(
    `/store/${params.storeId}/${params.productId}`
  );
  const availableStores = useFetch(
    `/product/${params.productId}/available-stores`
  );

  const [quantity, setQuantity] = useState(1);
  const isOutOfStock = storeQuantity.data?.quantity === 0;

  const orderMutation = useMakeOrderMutation();

  const [orderConfirmOpen, setOrderConfirmOpen] = useState(false);
  const [orderSuccessOpen, setOrderSuccessOpen] = useState(false);
  const [notEnoughOpen, setNotEnoughOpen] = useState(false);
  const [orderErrorOpen, setOrderErrorOpen] = useState(false);

  const handleClickOrder = () => {
    if (storeQuantity.data?.quantity < quantity) {
      setNotEnoughOpen(true);
      return;
    }

    setOrderConfirmOpen(true);
  };

  const makeOrder = async () => {
    try {
      await orderMutation.makeOrder(params.storeId, {
        products: [
          {
            productId: params.productId,
            quantity,
          },
        ],
      });
      setOrderConfirmOpen(false);
      setOrderSuccessOpen(true);
    } catch (err) {
      setOrderConfirmOpen(false);
      setOrderErrorOpen(true);
    }
  };

  if (loading) {
    return (
      <Box display="flex" justifyContent="center" padding={8}>
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return (
      <Box display="flex" justifyContent="center" padding={8}>
        <Typography variant="h6" color="error">
          {error.message}
        </Typography>
      </Box>
    );
  }
  return (
    <>
      <Container maxWidth="md">
        <Box margin="auto" paddingY={2}>
          <Breadcrumb
            store={{ name: store.data?.store.name, link: `/${params.storeId}` }}
            product={{ name: data?.name, link: `/${params.productId}` }}
          />
        </Box>
      </Container>

      <Container maxWidth="md">
        <Card key={store.id} sx={{ width: '100%', display: 'flex' }}>
          <CardMedia
            component="img"
            sx={{
              width: 500,
              alignSelf: 'stretch',
              height: 440,
              objectFit: 'contain',
              border: '1px solid #e0e0e0',
            }}
            image={data?.images[0]}
            alt={data?.name}
          />
          <CardContent sx={{ flex: 2 }}>
            <CardContent sx={{ flex: '1 0 auto' }}>
              <Typography variant="h4" fontWeight="bold" gutterBottom>
                {data?.name}
              </Typography>

              <Typography
                variant="h4"
                fontWeight="bold"
                color={colors.red[600]}
                gutterBottom
              >
                {priceFormatter.format(data?.price)}
              </Typography>

              <Stack spacing={1}>
                <Typography>
                  <b>Condition: </b>
                  <Typography
                    fontWeight="bold"
                    component="span"
                    color={
                      data?.isUsed ? colors.orange[600] : colors.green[600]
                    }
                  >
                    {data?.isUsed ? 'Used' : 'New'}
                  </Typography>
                </Typography>
                <Typography>
                  <b>Guitar type: </b>
                  <Typography component="span">{data?.guitarType}</Typography>
                </Typography>
                <Typography>
                  <b>Manufacturer: </b>
                  <Typography component="span">
                    {data?.productManufacturers
                      ?.map((manufacturer) => manufacturer.name)
                      .join(', ')}
                  </Typography>
                </Typography>
                <Typography>
                  <b>Country: </b>
                  <Typography component="span">
                    {data?.productManufacturers
                      ?.map((manufacturer) => manufacturer.country)
                      .join(', ')}
                  </Typography>
                </Typography>
              </Stack>

              {isOutOfStock ? (
                <Box marginTop={6} border="1px dashed red">
                  <Typography
                    align="center"
                    fontWeight={600}
                    fontSize={24}
                    color="error"
                  >
                    Out of stock
                  </Typography>
                </Box>
              ) : (
                <Box paddingTop={3}>
                  <Typography gutterBottom>Quantity:</Typography>
                  <Stack spacing={2} direction="row">
                    <ButtonGroup
                      variant="outlined"
                      aria-label="Basic button group"
                    >
                      <Button
                        onClick={() => setQuantity((x) => (x > 1 ? x - 1 : x))}
                      >
                        -
                      </Button>
                      <Button sx={{ width: 60, pointerEvents: 'none' }}>
                        {quantity}
                      </Button>
                      <Button
                        onClick={() => setQuantity((x) => (x < 5 ? x + 1 : x))}
                      >
                        +
                      </Button>
                    </ButtonGroup>
                    <Button
                      fullWidth
                      variant="contained"
                      color="primary"
                      onClick={handleClickOrder}
                    >
                      Order
                    </Button>
                  </Stack>
                </Box>
              )}
            </CardContent>
          </CardContent>
        </Card>

        {isOutOfStock && (
          <Box marginY={2}>
            <Typography variant="h5" fontWeight="bold" gutterBottom>
              Product is available in the following stores:
            </Typography>

            <Box height={200} overflow="auto" p={2} paddingTop={1}>
              <Grid container spacing={2}>
                {availableStores.data?.map((store) => (
                  <Grid item key={store.id} xs={12} sm={6}>
                    <Card key={store.id}>
                      <CardActionArea
                        LinkComponent={Link}
                        to={`/${store.id}?name=${data.name}`}
                      >
                        <CardContent>
                          <Typography
                            variant="subtitle1"
                            fontWeight="bold"
                            gutterBottom
                          >
                            {store.name}
                          </Typography>

                          <Typography
                            variant="subtitle1"
                            color="text.secondary"
                            component="div"
                          >
                            {store.address.street}, {store.address.city},{' '}
                            {store.address.postalCode}
                          </Typography>
                        </CardContent>
                      </CardActionArea>
                    </Card>
                  </Grid>
                ))}
              </Grid>
            </Box>
          </Box>
        )}

        <Box marginY={2}>
          <Typography variant="subtitle1" fontWeight="bold" gutterBottom>
            Description
          </Typography>
          <Typography>{data?.description}</Typography>
        </Box>
      </Container>

      {/* Order confirmation */}
      <ConfirmDialog
        open={orderConfirmOpen}
        title="Do you confirm order?"
        textContent={
          <Box width={300}>
            <Typography fontWeight="bold">
              Product: <Typography component="span">{data?.name}</Typography>
            </Typography>
            <Typography fontWeight="bold">
              Quantity: <Typography component="span">{quantity}</Typography>
            </Typography>
            <Typography fontWeight="bold">
              Total price:{' '}
              <Typography
                component="span"
                fontWeight="bold"
                color={colors.red[600]}
              >
                {priceFormatter.format(quantity * data.price)}
              </Typography>
            </Typography>
          </Box>
        }
        actions={
          <>
            <Button
              onClick={() => setOrderConfirmOpen(false)}
              variant="outlined"
              color="error"
              disabled={orderMutation.loading}
            >
              Cancel
            </Button>
            <Button
              onClick={makeOrder}
              variant="contained"
              color="primary"
              disabled={orderMutation.loading}
              startIcon={
                orderMutation.loading ? (
                  <CircularProgress color="inherit" size={16} />
                ) : undefined
              }
            >
              Confirm
            </Button>
          </>
        }
      />

      {/* Order success */}
      <ConfirmDialog
        open={orderSuccessOpen}
        title="Success!"
        textContent={
          <Box width={320}>
            <Typography align="center">
              Order has been places successfully! 🎉
            </Typography>
          </Box>
        }
        actions={
          <>
            <Button
              variant="contained"
              color="primary"
              component={Link}
              to={`/${params.storeId}`}
            >
              Done
            </Button>
          </>
        }
      />

      {/* Order error */}
      <ConfirmDialog
        open={orderErrorOpen}
        title="Someting went wrong!"
        textContent={
          <Box width={320}>
            <Typography align="center">
              There was an error while placing the order. 😢
            </Typography>
            <Typography align="center" color="red">
              {orderMutation.error?.message}
            </Typography>
          </Box>
        }
        actions={
          <>
            <Button
              variant="contained"
              color="primary"
              onClick={() => setOrderErrorOpen(false)}
            >
              Done
            </Button>
          </>
        }
      />

      {/* Not enough in stock */}
      <ConfirmDialog
        open={notEnoughOpen}
        title="Not enough in stock!"
        textContent={
          <Box width={320}>
            <Typography>
              Product is not available in the desired quantity.
              <br /> Please reduce the quantity or try again later.
            </Typography>
          </Box>
        }
        actions={
          <>
            <Button
              variant="contained"
              color="primary"
              onClick={() => setNotEnoughOpen(false)}
            >
              Ok
            </Button>
          </>
        }
      />
    </>
  );
}
