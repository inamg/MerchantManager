import gql from 'graphql-tag';

export const ADD_MERCHANT = gql`
mutation MerchantMutation($merchant : MerchantInput)
{
  createMerchant(merchant: $merchant)
  {
    id,
    name,
    description
  }
}
`;

